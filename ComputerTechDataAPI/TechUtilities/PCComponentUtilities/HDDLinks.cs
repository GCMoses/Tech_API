using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class HDDLinks : IHDDLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<HDDDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public HDDLinks(LinkGenerator linkGenerator, IDataShaper<HDDDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<HDDDTO> hddDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedHDDs = ShapeData(hddDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedHDDs(hddDTO, fields, productId, httpContext, shapedHDDs);

        return ReturnShapedHDDs(shapedHDDs);
    }



    private List<Entity> ShapeData(IEnumerable<HDDDTO> hddsDTO, string fields) => _dataShaper.ShapeData(hddsDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedHDDs(List<Entity> shapedHDDs) =>
        new LinkResponse { ShapedEntities = shapedHDDs };
    private LinkResponse ReturnLinkedHDDs(IEnumerable<HDDDTO> hddsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedHDDs)
    {
        var hddDTOList = hddsDTO.ToList();
        for (var index = 0; index < hddDTOList.Count(); index++)
        {
            var hddLinks = CreateLinksForHDD(httpContext, productId,
           hddDTOList[index].Id, fields);
            shapedHDDs[index].Add("Links", hddLinks);
        }
        var hddCollection = new LinkCollectionWrapper<Entity>(shapedHDDs);
        var linkedHDDs = CreateLinksForHDDs(httpContext, hddCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedHDDs };
    }

    private List<Link> CreateLinksForHDD(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetHDDForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteHDDForProduct", values: new { productId, id }),
            "delete_hdd",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateHDDForProduct", values: new { productId, id }),
            "update_hdd",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateHDDForProduct", values: new { productId, id }),
            "partially_update_hdd",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForHDDs(HttpContext httpContext,
        LinkCollectionWrapper<Entity> hddsWrapper)
    {
        hddsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetHDDForProduct", values: new { }),
                "self",
                "GET"));

        return hddsWrapper;
    }
}
