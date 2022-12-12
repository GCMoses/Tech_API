using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class PSULinks : IPSULinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<PSUDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public PSULinks(LinkGenerator linkGenerator, IDataShaper<PSUDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }




    public LinkResponse TryGenerateLinks(IEnumerable<PSUDTO> psuDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedPSUs = ShapeData(psuDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedPSUs(psuDTO, fields, productId, httpContext, shapedPSUs);

        return ReturnShapedPSUs(shapedPSUs);
    }



    private List<Entity> ShapeData(IEnumerable<PSUDTO> psusDTO, string fields) => _dataShaper.ShapeData(psusDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedPSUs(List<Entity> shapedPSUs) =>
        new LinkResponse { ShapedEntities = shapedPSUs };
    private LinkResponse ReturnLinkedPSUs(IEnumerable<PSUDTO> psusDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedPSUs)
    {
        var psuDTOList = psusDTO.ToList();
        for (var index = 0; index < psuDTOList.Count(); index++)
        {
            var psuLinks = CreateLinksForPSU(httpContext, productId,
           psuDTOList[index].Id, fields);
            shapedPSUs[index].Add("Links", psuLinks);
        }
        var psuCollection = new LinkCollectionWrapper<Entity>(shapedPSUs);
        var linkedPSUs = CreateLinksForPSUs(httpContext, psuCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedPSUs };
    }

    private List<Link> CreateLinksForPSU(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetPSUForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeletePSUForProduct", values: new { productId, id }),
            "delete_psu",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdatePSUForProduct", values: new { productId, id }),
            "update_psu",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdatePSUForProduct", values: new { productId, id }),
            "partially_update_psu",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForPSUs(HttpContext httpContext,
        LinkCollectionWrapper<Entity> psusWrapper)
    {
        psusWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetPSUForProduct", values: new { }),
                "self",
                "GET"));

        return psusWrapper;
    }
}
