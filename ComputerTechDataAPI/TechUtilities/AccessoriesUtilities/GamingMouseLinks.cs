using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.AccessoriesUtilities;

public class GamingMouseLinks : IGamingMouseLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<GamingMouseDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public GamingMouseLinks(LinkGenerator linkGenerator, IDataShaper<GamingMouseDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<GamingMouseDTO> gamingMouseDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedGamingMouses = ShapeData(gamingMouseDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedGamingMouses(gamingMouseDTO, fields, productId, httpContext, shapedGamingMouses);

        return ReturnShapedGamingMouses(shapedGamingMouses);
    }



    private List<Entity> ShapeData(IEnumerable<GamingMouseDTO> gamingMousesDTO, string fields) =>
        _dataShaper.ShapeData(gamingMousesDTO, fields)  
            .Select(g => g.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedGamingMouses(List<Entity> shapedGamingMouses) =>
        new LinkResponse { ShapedEntities = shapedGamingMouses };

    private LinkResponse ReturnLinkedGamingMouses(IEnumerable<GamingMouseDTO> gamingMousesDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedGamingMouses)
    {
        var gamingMouseDTOList = gamingMousesDTO.ToList();
        for (var index = 0; index < gamingMouseDTOList.Count(); index++)
        {
            var gamingMouseLinks = CreateLinksForGamingMouse(httpContext, productId,
           gamingMouseDTOList[index].Id, fields);
            shapedGamingMouses[index].Add("Links", gamingMouseLinks);
        }
        var gamingMouseCollection = new LinkCollectionWrapper<Entity>(shapedGamingMouses);
        var linkedGamingMouses = CreateLinksForGamingMouses(httpContext, gamingMouseCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedGamingMouses };
    }

    private List<Link> CreateLinksForGamingMouse(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingMouseForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteGamingMouseForProduct", values: new { productId, id }),
            "delete_gamingMouse",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateGamingMouseForProduct", values: new { productId, id }),
            "update_gamingMouse",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateGamingMouseForProduct", values: new { productId, id }),
            "partially_update_gamingMouse",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForGamingMouses(HttpContext httpContext,
        LinkCollectionWrapper<Entity> gamingMousesWrapper)
    {
        gamingMousesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingMousesForProduct", values: new { }),
                "self",
                "GET"));

        return gamingMousesWrapper;
    }
}
