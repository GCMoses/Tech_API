using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class CPUCoolerLinks : ICPUCoolerLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<CPUCoolerDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public CPUCoolerLinks(LinkGenerator linkGenerator, IDataShaper<CPUCoolerDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<CPUCoolerDTO> cpuCoolerDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedCPUCoolers = ShapeData(cpuCoolerDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedCPUCoolers(cpuCoolerDTO, fields, productId, httpContext, shapedCPUCoolers);

        return ReturnShapedCPUCoolers(shapedCPUCoolers);
    }



    private List<Entity> ShapeData(IEnumerable<CPUCoolerDTO> cpuCoolersDTO, string fields) => _dataShaper.ShapeData(cpuCoolersDTO, fields)
            .Select(p => p.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedCPUCoolers(List<Entity> shapedCPUCoolers) =>
        new LinkResponse { ShapedEntities = shapedCPUCoolers };
    private LinkResponse ReturnLinkedCPUCoolers(IEnumerable<CPUCoolerDTO> cpuCoolersDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedCPUCoolers)
    {
        var cpuCoolerDTOList = cpuCoolersDTO.ToList();
        for (var index = 0; index < cpuCoolerDTOList.Count(); index++)
        {
            var cpuCoolerLinks = CreateLinksForCPUCooler(httpContext, productId,
           cpuCoolerDTOList[index].Id, fields);
            shapedCPUCoolers[index].Add("Links", cpuCoolerLinks);
        }
        var cpuCoolerCollection = new LinkCollectionWrapper<Entity>(shapedCPUCoolers);
        var linkedCPUCoolers = CreateLinksForCPUCoolers(httpContext, cpuCoolerCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedCPUCoolers };
    }

    private List<Link> CreateLinksForCPUCooler(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetCPUCoolerForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteCPUCoolerForProduct", values: new { productId, id }),
            "delete_cpuCooler",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateCPUCoolerForProduct", values: new { productId, id }),
            "update_cpuCooler",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateCPUCoolerForProduct", values: new { productId, id }),
            "partially_update_cpuCooler",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForCPUCoolers(HttpContext httpContext,
        LinkCollectionWrapper<Entity> cpuCoolersWrapper)
    {
        cpuCoolersWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetCPUCoolerForProduct", values: new { }),
                "self",
                "GET"));

        return cpuCoolersWrapper;
    }
}
