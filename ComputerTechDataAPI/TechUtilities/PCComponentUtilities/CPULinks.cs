using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class CPULinks : ICPULinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<CPUDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public CPULinks(LinkGenerator linkGenerator, IDataShaper<CPUDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<CPUDTO> cpuDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedCPUs = ShapeData(cpuDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedCPUs(cpuDTO, fields, productId, httpContext, shapedCPUs);

        return ReturnShapedCPUs(shapedCPUs);
    }



    private List<Entity> ShapeData(IEnumerable<CPUDTO> cpusDTO, string fields) => _dataShaper.ShapeData(cpusDTO, fields)
            .Select(p => p.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedCPUs(List<Entity> shapedCPUs) =>
        new LinkResponse { ShapedEntities = shapedCPUs };
    private LinkResponse ReturnLinkedCPUs(IEnumerable<CPUDTO> cpusDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedCPUs)
    {
        var cpuDTOList = cpusDTO.ToList();
        for (var index = 0; index < cpuDTOList.Count(); index++)
        {
            var cpuLinks = CreateLinksForCPU(httpContext, productId,
           cpuDTOList[index].Id, fields);
            shapedCPUs[index].Add("Links", cpuLinks);
        }
        var cpuCollection = new LinkCollectionWrapper<Entity>(shapedCPUs);
        var linkedCPUs = CreateLinksForCPUs(httpContext, cpuCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedCPUs };
    }

    private List<Link> CreateLinksForCPU(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetCPUForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteCPUForProduct", values: new { productId, id }),
            "delete_cpu",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateCPUForProduct", values: new { productId, id }),
            "update_cpu",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateCPUForProduct", values: new { productId, id }),
            "partially_update_cpu",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForCPUs(HttpContext httpContext,
        LinkCollectionWrapper<Entity> cpusWrapper)
    {
        cpusWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetCPUForProduct", values: new { }),
                "self",
                "GET"));

        return cpusWrapper;
    }
}
