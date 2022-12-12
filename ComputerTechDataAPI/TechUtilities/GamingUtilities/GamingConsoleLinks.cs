using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.GamingUtilities;

public class GamingConsoleLinks : IGamingConsoleLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<GamingConsoleDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public GamingConsoleLinks(LinkGenerator linkGenerator, IDataShaper<GamingConsoleDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<GamingConsoleDTO> gamingConsoleDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedGamingConsoles = ShapeData(gamingConsoleDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedGamingConsoles(gamingConsoleDTO, fields, productId, httpContext, shapedGamingConsoles);

        return ReturnShapedGamingConsoles(shapedGamingConsoles);
    }



    private List<Entity> ShapeData(IEnumerable<GamingConsoleDTO> gamingConsolesDTO, string fields) =>
        _dataShaper.ShapeData(gamingConsolesDTO, fields)
            .Select(g => g.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedGamingConsoles(List<Entity> shapedGamingConsoles) =>
        new LinkResponse { ShapedEntities = shapedGamingConsoles };

    private LinkResponse ReturnLinkedGamingConsoles(IEnumerable<GamingConsoleDTO> gamingConsolesDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedGamingConsoles)
    {
        var gamingConsoleDTOList = gamingConsolesDTO.ToList();
        for (var index = 0; index < gamingConsoleDTOList.Count(); index++)
        {
            var gamingConsoleLinks = CreateLinksForGamingConsole(httpContext, productId,
           gamingConsoleDTOList[index].Id, fields);
            shapedGamingConsoles[index].Add("Links", gamingConsoleLinks);
        }
        var gamingConsoleCollection = new LinkCollectionWrapper<Entity>(shapedGamingConsoles);
        var linkedGamingConsoles = CreateLinksForGamingConsoles(httpContext, gamingConsoleCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedGamingConsoles };
    }

    private List<Link> CreateLinksForGamingConsole(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingConsoleForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteGamingConsoleForProduct", values: new { productId, id }),
            "delete_gamingConsole",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateGamingConsoleForProduct", values: new { productId, id }),
            "update_gamingConsole",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateGamingConsoleForProduct", values: new { productId, id }),
            "partially_update_gaminConsole",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForGamingConsoles(HttpContext httpContext,
        LinkCollectionWrapper<Entity> gamingConsolesWrapper)
    {
        gamingConsolesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingConsolesForProduct", values: new { }),
                "self",
                "GET"));

        return gamingConsolesWrapper;
    }
}
