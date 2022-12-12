using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class CaseLinks : ICaseLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<CaseDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public CaseLinks(LinkGenerator linkGenerator, IDataShaper<CaseDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<CaseDTO> pcCaseDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedCases = ShapeData(pcCaseDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedCases(pcCaseDTO, fields, productId, httpContext, shapedCases);

        return ReturnShapedCases(shapedCases);
    }



    private List<Entity> ShapeData(IEnumerable<CaseDTO> pcCasesDTO, string fields) => _dataShaper.ShapeData(pcCasesDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedCases(List<Entity> shapedCases) =>
        new LinkResponse { ShapedEntities = shapedCases };
    private LinkResponse ReturnLinkedCases(IEnumerable<CaseDTO> pcCasesDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedCases)
    {
        var pcCaseDTOList = pcCasesDTO.ToList();
        for (var index = 0; index < pcCaseDTOList.Count(); index++)
        {
            var pcCaseLinks = CreateLinksForCase(httpContext, productId,
           pcCaseDTOList[index].Id, fields);
            shapedCases[index].Add("Links", pcCaseLinks);
        }
        var pcCaseCollection = new LinkCollectionWrapper<Entity>(shapedCases);
        var linkedCases = CreateLinksForCases(httpContext, pcCaseCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedCases };
    }

    private List<Link> CreateLinksForCase(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetCaseForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteCaseForProduct", values: new { productId, id }),
            "delete_pcCase",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateCaseForProduct", values: new { productId, id }),
            "update_pcCase",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateCaseForProduct", values: new { productId, id }),
            "partially_update_pcCase",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForCases(HttpContext httpContext,
        LinkCollectionWrapper<Entity> pcCasesWrapper)
    {
        pcCasesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetCaseForProduct", values: new { }),
                "self",
                "GET"));

        return pcCasesWrapper;
    }
}
