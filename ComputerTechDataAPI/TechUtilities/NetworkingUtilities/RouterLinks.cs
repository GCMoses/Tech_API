using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.INetworkingLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.NetworkingUtilities;

public class RouterLinks : IRouterLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<RouterDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public RouterLinks(LinkGenerator linkGenerator, IDataShaper<RouterDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<RouterDTO> routerDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedRouters = ShapeData(routerDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedRouters(routerDTO, fields, productId, httpContext, shapedRouters);

        return ReturnShapedRouters(shapedRouters);
    }



    private List<Entity> ShapeData(IEnumerable<RouterDTO> routersDTO, string fields) => _dataShaper.ShapeData(routersDTO, fields)
            .Select(r => r.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedRouters(List<Entity> shapedRouters) =>
        new LinkResponse { ShapedEntities = shapedRouters };

    private LinkResponse ReturnLinkedRouters(IEnumerable<RouterDTO> routersDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedRouters)
    {
        var routerDTOList = routersDTO.ToList();
        for (var index = 0; index < routerDTOList.Count(); index++)
        {
            var routerLinks = CreateLinksForRouter(httpContext, productId,
           routerDTOList[index].Id, fields);
            shapedRouters[index].Add("Links", routerLinks);
        }
        var routerCollection = new LinkCollectionWrapper<Entity>(shapedRouters);
        var linkedRouters = CreateLinksForRouters(httpContext, routerCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedRouters };
    }

    private List<Link> CreateLinksForRouter(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetRouterForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteRouterForProduct", values: new { productId, id }),
            "delete_router",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateRouterForProduct", values: new { productId, id }),
            "update_router",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateRouterForProduct", values: new { productId, id }),
            "partially_update_router",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForRouters(HttpContext httpContext,
        LinkCollectionWrapper<Entity> routersWrapper)
    {
        routersWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetRouterForProduct", values: new { }),
                "self",
                "GET"));

        return routersWrapper;
    }
}
