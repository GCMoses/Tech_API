using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class SSDLinks : ISSDLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<SSDDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public SSDLinks(LinkGenerator linkGenerator, IDataShaper<SSDDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<SSDDTO> ssdDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedSSDs = ShapeData(ssdDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedSSDs(ssdDTO, fields, productId, httpContext, shapedSSDs);

        return ReturnShapedSSDs(shapedSSDs);
    }



    private List<Entity> ShapeData(IEnumerable<SSDDTO> ssdsDTO, string fields) => _dataShaper.ShapeData(ssdsDTO, fields)
            .Select(p => p.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedSSDs(List<Entity> shapedSSDs) =>
        new LinkResponse { ShapedEntities = shapedSSDs };

    private LinkResponse ReturnLinkedSSDs(IEnumerable<SSDDTO> ssdsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedSSDs)
    {
        var ssdDTOList = ssdsDTO.ToList();
        for (var index = 0; index < ssdDTOList.Count(); index++)
        {
            var ssdLinks = CreateLinksForSSD(httpContext, productId,
           ssdDTOList[index].Id, fields);
            shapedSSDs[index].Add("Links", ssdLinks);
        }
        var ssdCollection = new LinkCollectionWrapper<Entity>(shapedSSDs);
        var linkedSSDs = CreateLinksForSSDs(httpContext, ssdCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedSSDs };
    }

    private List<Link> CreateLinksForSSD(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetSSDForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteSSDForProduct", values: new { productId, id }),
            "delete_ssd",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateSSDForProduct", values: new { productId, id }),
            "update_ssd",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateSSDForProduct", values: new { productId, id }),
            "partially_update_ssd",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForSSDs(HttpContext httpContext,
        LinkCollectionWrapper<Entity> ssdsWrapper)
    {
        ssdsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetSSDForProduct", values: new { }),
                "self",
                "GET"));

        return ssdsWrapper;
    }
}
