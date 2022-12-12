using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class DesktopLinks : IDesktopLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<DesktopDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public DesktopLinks(LinkGenerator linkGenerator, IDataShaper<DesktopDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<DesktopDTO> desktopDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedDesktops = ShapeData(desktopDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedDesktops(desktopDTO, fields, productId, httpContext, shapedDesktops);

        return ReturnShapedDesktops(shapedDesktops);
    }



    private List<Entity> ShapeData(IEnumerable<DesktopDTO> desktopsDTO, string fields) => _dataShaper.ShapeData(desktopsDTO, fields)
            .Select(p => p.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedDesktops(List<Entity> shapedDesktops) =>
        new LinkResponse { ShapedEntities = shapedDesktops };

    private LinkResponse ReturnLinkedDesktops(IEnumerable<DesktopDTO> desktopsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedDesktops)
    {
        var desktopDTOList = desktopsDTO.ToList();
        for (var index = 0; index < desktopDTOList.Count(); index++)
        {
            var desktopLinks = CreateLinksForDesktop(httpContext, productId,
           desktopDTOList[index].Id, fields);
            shapedDesktops[index].Add("Links", desktopLinks);
        }
        var desktopCollection = new LinkCollectionWrapper<Entity>(shapedDesktops);
        var linkedDesktops = CreateLinksForDesktops(httpContext, desktopCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedDesktops };
    }

    private List<Link> CreateLinksForDesktop(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetDesktopForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteDesktopForProduct", values: new { productId, id }),
            "delete_desktop",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateDesktopForProduct", values: new { productId, id }),
            "update_desktop",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateDesktopForProduct", values: new { productId, id }),
            "partially_update_desktop",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForDesktops(HttpContext httpContext,
        LinkCollectionWrapper<Entity> desktopsWrapper)
    {
        desktopsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetDesktopForProduct", values: new { }),
                "self",
                "GET"));

        return desktopsWrapper;
    }
}
