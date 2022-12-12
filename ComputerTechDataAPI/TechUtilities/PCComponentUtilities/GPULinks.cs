using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class GPULinks : IGPULinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<GPUDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public GPULinks(LinkGenerator linkGenerator, IDataShaper<GPUDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<GPUDTO> gpuDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedGPUs = ShapeData(gpuDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedGPUs(gpuDTO, fields, productId, httpContext, shapedGPUs);

        return ReturnShapedGPUs(shapedGPUs);
    }



    private List<Entity> ShapeData(IEnumerable<GPUDTO> gpusDTO, string fields) => _dataShaper.ShapeData(gpusDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedGPUs(List<Entity> shapedGPUs) =>
        new LinkResponse { ShapedEntities = shapedGPUs };
    private LinkResponse ReturnLinkedGPUs(IEnumerable<GPUDTO> gpusDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedGPUs)
    {
        var gpuDTOList = gpusDTO.ToList();
        for (var index = 0; index < gpuDTOList.Count(); index++)
        {
            var gpuLinks = CreateLinksForGPU(httpContext, productId,
           gpuDTOList[index].Id, fields);
            shapedGPUs[index].Add("Links", gpuLinks);
        }
        var gpuCollection = new LinkCollectionWrapper<Entity>(shapedGPUs);
        var linkedGPUs = CreateLinksForGPUs(httpContext, gpuCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedGPUs };
    }

    private List<Link> CreateLinksForGPU(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetGPUForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteGPUForProduct", values: new { productId, id }),
            "delete_gpu",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateGPUForProduct", values: new { productId, id }),
            "update_gpu",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateGPUForProduct", values: new { productId, id }),
            "partially_update_gpu",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForGPUs(HttpContext httpContext,
        LinkCollectionWrapper<Entity> gpusWrapper)
    {
        gpusWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetGPUForProduct", values: new { }),
                "self",
                "GET"));

        return gpusWrapper;
    }
}
