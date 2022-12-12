using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.GamingUtilities;

public class GamingLaptopLinks : IGamingLaptopLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<GamingLaptopDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public GamingLaptopLinks(LinkGenerator linkGenerator, IDataShaper<GamingLaptopDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<GamingLaptopDTO> gamingLaptopDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedGamingLaptops = ShapeData(gamingLaptopDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedGamingLaptops(gamingLaptopDTO, fields, productId, httpContext, shapedGamingLaptops);

        return ReturnShapedGamingLaptops(shapedGamingLaptops);
    }



    private List<Entity> ShapeData(IEnumerable<GamingLaptopDTO> gamingLaptopsDTO, string fields) =>
        _dataShaper.ShapeData(gamingLaptopsDTO, fields)
            .Select(g => g.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedGamingLaptops(List<Entity> shapedGamingLaptops) =>
        new LinkResponse { ShapedEntities = shapedGamingLaptops };

    private LinkResponse ReturnLinkedGamingLaptops(IEnumerable<GamingLaptopDTO> gamingLaptopsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedGamingLaptops)
    {
        var gamingLaptopDTOList = gamingLaptopsDTO.ToList();
        for (var index = 0; index < gamingLaptopDTOList.Count(); index++)
        {
            var gamingLaptopLinks = CreateLinksForGamingLaptop(httpContext, productId,
           gamingLaptopDTOList[index].Id, fields);
            shapedGamingLaptops[index].Add("Links", gamingLaptopLinks);
        }
        var gamingLaptopCollection = new LinkCollectionWrapper<Entity>(shapedGamingLaptops);
        var linkedGamingLaptops = CreateLinksForGamingLaptops(httpContext, gamingLaptopCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedGamingLaptops };
    }

    private List<Link> CreateLinksForGamingLaptop(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingLaptopForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteGamingLaptopForProduct", values: new { productId, id }),
            "delete_gamingLaptop",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateGamingLaptopForProduct", values: new { productId, id }),
            "update_gamingLaptop",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateGamingLaptopForProduct", values: new { productId, id }),
            "partially_update_gamingLaptop",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForGamingLaptops(HttpContext httpContext,
        LinkCollectionWrapper<Entity> gamingLaptopsWrapper)
    {
        gamingLaptopsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingLaptopsForProduct", values: new { }),
                "self",
                "GET"));

        return gamingLaptopsWrapper;
    }
}
