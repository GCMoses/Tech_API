using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.AccessoriesUtilities;

public class GamingHeadphonesAndHeadsetLinks : IGamingHeadphonesAndHeadsetLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<GamingHeadphonesAndHeadsetDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public GamingHeadphonesAndHeadsetLinks(LinkGenerator linkGenerator, IDataShaper<GamingHeadphonesAndHeadsetDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<GamingHeadphonesAndHeadsetDTO> gamingHeadphonesAndHeadsetDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedGamingHeadphonesAndHeadsets = ShapeData(gamingHeadphonesAndHeadsetDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedGamingHeadphonesAndHeadsets(gamingHeadphonesAndHeadsetDTO, fields, productId, httpContext, shapedGamingHeadphonesAndHeadsets);

        return ReturnShapedGamingHeadphonesAndHeadsets(shapedGamingHeadphonesAndHeadsets);
    }



    private List<Entity> ShapeData(IEnumerable<GamingHeadphonesAndHeadsetDTO> gamingHeadphonesAndHeadsetsDTO, string fields) =>
        _dataShaper.ShapeData(gamingHeadphonesAndHeadsetsDTO, fields)
            .Select(g => g.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedGamingHeadphonesAndHeadsets(List<Entity> shapedGamingHeadphonesAndHeadsets) =>
        new LinkResponse { ShapedEntities = shapedGamingHeadphonesAndHeadsets };

    private LinkResponse ReturnLinkedGamingHeadphonesAndHeadsets(IEnumerable<GamingHeadphonesAndHeadsetDTO> gamingHeadphonesAndHeadsetsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedGamingHeadphonesAndHeadsets)
    {
        var gamingHeadphonesAndHeadsetDTOList = gamingHeadphonesAndHeadsetsDTO.ToList();
        for (var index = 0; index < gamingHeadphonesAndHeadsetDTOList.Count(); index++)
        {
            var gamingHeadphonesAndHeadsetLinks = CreateLinksForGamingHeadphonesAndHeadset(httpContext, productId,
           gamingHeadphonesAndHeadsetDTOList[index].Id, fields);
            shapedGamingHeadphonesAndHeadsets[index].Add("Links", gamingHeadphonesAndHeadsetLinks);
        }
        var gamingHeadphonesAndHeadsetCollection = new LinkCollectionWrapper<Entity>(shapedGamingHeadphonesAndHeadsets);
        var linkedGamingHeadphonesAndHeadsets = CreateLinksForGamingHeadphonesAndHeadsets(httpContext, gamingHeadphonesAndHeadsetCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedGamingHeadphonesAndHeadsets };
    }

    private List<Link> CreateLinksForGamingHeadphonesAndHeadset(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingHeadphonesAndHeadsetForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteGamingHeadphonesAndHeadsetForProduct", values: new { productId, id }),
            "delete_gamingHeadphonesAndHeadset",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateGamingHeadphonesAndHeadsetForProduct", values: new { productId, id }),
            "update_gamingHeadphonesAndHeadset",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateGamingHeadphonesAndHeadsetForProduct", values: new { productId, id }),
            "partially_update_gamingHeadphonesAndHeadset",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForGamingHeadphonesAndHeadsets(HttpContext httpContext,
        LinkCollectionWrapper<Entity> gamingHeadphonesAndHeadsetsWrapper)
    {
        gamingHeadphonesAndHeadsetsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetGamingHeadphonesAndHeadsetsForProduct", values: new { }),
                "self",
                "GET"));

        return gamingHeadphonesAndHeadsetsWrapper;
    }
}
