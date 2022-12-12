using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.AccessoriesUtilities;

public class GamingKeyboardLinks : IGamingKeyboardLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<GamingKeyboardDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public GamingKeyboardLinks(LinkGenerator linkGenerator, IDataShaper<GamingKeyboardDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<GamingKeyboardDTO> gamingKeyboardDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedGamingKeyboards = ShapeData(gamingKeyboardDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedGamingKeyboards(gamingKeyboardDTO, fields, productId, httpContext, shapedGamingKeyboards);

        return ReturnShapedGamingKeyboards(shapedGamingKeyboards);
    }



    private List<Entity> ShapeData(IEnumerable<GamingKeyboardDTO> gamingKeyboardsDTO, string fields) =>
        _dataShaper.ShapeData(gamingKeyboardsDTO, fields)
            .Select(g => g.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedGamingKeyboards(List<Entity> shapedGamingKeyboards) =>
        new LinkResponse { ShapedEntities = shapedGamingKeyboards };

    private LinkResponse ReturnLinkedGamingKeyboards(IEnumerable<GamingKeyboardDTO> gamingKeyboardsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedGamingKeyboards)
    {
        var gamingKeyboardDTOList = gamingKeyboardsDTO.ToList();
        for (var index = 0; index < gamingKeyboardDTOList.Count(); index++)
        {
            var gamingKeyboardLinks = CreateLinksForGamingKeyboard(httpContext, productId,
           gamingKeyboardDTOList[index].Id, fields);
            shapedGamingKeyboards[index].Add("Links", gamingKeyboardLinks);
        }
        var gamingKeyboardCollection = new LinkCollectionWrapper<Entity>(shapedGamingKeyboards);
        var linkedGamingKeyboards = CreateLinksForGamingKeyboards(httpContext, gamingKeyboardCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedGamingKeyboards };
    }

    private List<Link> CreateLinksForGamingKeyboard(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingKeyboardForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteGamingKeyboardForProduct", values: new { productId, id }),
            "delete_gamingKeyboard",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateGamingKeyboardForProduct", values: new { productId, id }),
            "update_gamingKeyboard",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateGamingKeyboardForProduct", values: new { productId, id }),
            "partially_update_gamingKeyboard",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForGamingKeyboards(HttpContext httpContext,
        LinkCollectionWrapper<Entity> gamingKeyboardsWrapper)
    {
        gamingKeyboardsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingKeyboardsForProduct", values: new { }),
                "self",
                "GET"));

        return gamingKeyboardsWrapper;
    }
}
