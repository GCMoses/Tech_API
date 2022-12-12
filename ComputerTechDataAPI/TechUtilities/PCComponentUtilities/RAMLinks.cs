using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class RAMLinks : IRAMLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<RAMDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public RAMLinks(LinkGenerator linkGenerator, IDataShaper<RAMDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<RAMDTO> ramDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedRAMs = ShapeData(ramDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedRAMs(ramDTO, fields, productId, httpContext, shapedRAMs);

        return ReturnShapedRAMs(shapedRAMs);
    }



    private List<Entity> ShapeData(IEnumerable<RAMDTO> ramsDTO, string fields) => _dataShaper.ShapeData(ramsDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedRAMs(List<Entity> shapedRAMs) =>
        new LinkResponse { ShapedEntities = shapedRAMs };
    private LinkResponse ReturnLinkedRAMs(IEnumerable<RAMDTO>ramsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedRAMs)
    {
        var ramDTOList = ramsDTO.ToList();
        for (var index = 0; index < ramDTOList.Count(); index++)
        {
            var ramLinks = CreateLinksForRAM(httpContext, productId,
           ramDTOList[index].Id, fields);
            shapedRAMs[index].Add("Links", ramLinks);
        }
        var ramCollection = new LinkCollectionWrapper<Entity>(shapedRAMs);
        var linkedRAMs = CreateLinksForRAMs(httpContext, ramCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedRAMs };
    }

    private List<Link> CreateLinksForRAM(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetRAMForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteRAMForProduct", values: new { productId, id }),
            "delete_ram",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateRAMForProduct", values: new { productId, id }),
            "update_ram",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateRAMForProduct", values: new { productId, id }),
            "partially_update_ram",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForRAMs(HttpContext httpContext,
        LinkCollectionWrapper<Entity> ramsWrapper)
    {
        ramsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetRAMForProduct", values: new { }),
                "self",
                "GET"));

        return ramsWrapper;
    }
}
