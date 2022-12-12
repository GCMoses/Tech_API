using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class MotherboardLinks : IMotherboardLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<MotherboardDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public MotherboardLinks(LinkGenerator linkGenerator, IDataShaper<MotherboardDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<MotherboardDTO> motherboardDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedMotherboards = ShapeData(motherboardDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedMotherboards(motherboardDTO, fields, productId, httpContext, shapedMotherboards);

        return ReturnShapedMotherboards(shapedMotherboards);
    }



    private List<Entity> ShapeData(IEnumerable<MotherboardDTO> motherboardsDTO, string fields) => _dataShaper.ShapeData
            (motherboardsDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedMotherboards(List<Entity> shapedMotherboards) =>
        new LinkResponse { ShapedEntities = shapedMotherboards };
    private LinkResponse ReturnLinkedMotherboards(IEnumerable<MotherboardDTO> motherboardsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedMotherboards)
    {
        var motherboardDTOList = motherboardsDTO.ToList();
        for (var index = 0; index < motherboardDTOList.Count(); index++)
        {
            var motherboardLinks = CreateLinksForMotherboard(httpContext, productId,
           motherboardDTOList[index].Id, fields);
            shapedMotherboards[index].Add("Links", motherboardLinks);
        }
        var motherboardCollection = new LinkCollectionWrapper<Entity>(shapedMotherboards);
        var linkedMotherboards = CreateLinksForMotherboards(httpContext, motherboardCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedMotherboards };
    }
        
    private List<Link> CreateLinksForMotherboard(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetMotherboardForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteMotherboardForProduct", values: new { productId, id }),
            "delete_motherboard",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateMotherboardForProduct", values: new { productId, id }),
            "update_motherboard",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateMotherboardForProduct", values: new { productId, id }),
            "partially_update_motherboard",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForMotherboards(HttpContext httpContext,
        LinkCollectionWrapper<Entity> motherboardsWrapper)
    {
        motherboardsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetMotherboardForProduct", values: new { }),
                "self",
                "GET"));

        return motherboardsWrapper;
    }
}
