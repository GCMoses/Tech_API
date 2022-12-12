using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.GamingUtilities;

public class GamingDesktopLinks : IGamingDesktopLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<GamingDesktopDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public GamingDesktopLinks(LinkGenerator linkGenerator, IDataShaper<GamingDesktopDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<GamingDesktopDTO> gamingDesktopDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedGamingDesktops = ShapeData(gamingDesktopDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedGamingDesktops(gamingDesktopDTO, fields, productId, httpContext, shapedGamingDesktops);

        return ReturnShapedGamingDesktops(shapedGamingDesktops);
    }



    private List<Entity> ShapeData(IEnumerable<GamingDesktopDTO> gamingDesktopsDTO, string fields) =>
        _dataShaper.ShapeData(gamingDesktopsDTO, fields)
            .Select(g => g.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedGamingDesktops(List<Entity> shapedGamingDesktops) =>
        new LinkResponse { ShapedEntities = shapedGamingDesktops };

    private LinkResponse ReturnLinkedGamingDesktops(IEnumerable<GamingDesktopDTO> gamingDesktopsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedGamingDesktops)
    {
        var gamingDesktopDTOList = gamingDesktopsDTO.ToList();
        for (var index = 0; index < gamingDesktopDTOList.Count(); index++)
        {
            var gamingDesktopLinks = CreateLinksForGamingDesktop(httpContext, productId,
           gamingDesktopDTOList[index].Id, fields);
            shapedGamingDesktops[index].Add("Links", gamingDesktopLinks);
        }
        var gamingDesktopCollection = new LinkCollectionWrapper<Entity>(shapedGamingDesktops);
        var linkedGamingDesktops = CreateLinksForGamingDesktops(httpContext, gamingDesktopCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedGamingDesktops };
    }

    private List<Link> CreateLinksForGamingDesktop(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingDesktopForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteGamingDesktopForProduct", values: new { productId, id }),
            "delete_gamingDesktop",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateGamingDesktopForProduct", values: new { productId, id }),
            "update_gamingDesktop",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateGamingDesktopForProduct", values: new { productId, id }),
            "partially_update_gamingDesktop",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForGamingDesktops(HttpContext httpContext,
        LinkCollectionWrapper<Entity> gamingDesktopsWrapper)
    {
        gamingDesktopsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingDesktopsForProduct", values: new { }),
                "self",
                "GET"));

        return gamingDesktopsWrapper;
    }
}
