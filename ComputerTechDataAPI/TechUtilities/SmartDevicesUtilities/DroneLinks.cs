using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.ISMartDevicesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.SmartDevicesUtilities;

public class DroneLinks : IDroneLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<DroneDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public DroneLinks(LinkGenerator linkGenerator, IDataShaper<DroneDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<DroneDTO> droneDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedDrones = ShapeData(droneDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedDrones(droneDTO, fields, productId, httpContext, shapedDrones);

        return ReturnShapedDrones(shapedDrones);
    }



    private List<Entity> ShapeData(IEnumerable<DroneDTO> dronesDTO, string fields) => _dataShaper.ShapeData(dronesDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedDrones(List<Entity> shapedDrones) =>
        new LinkResponse { ShapedEntities = shapedDrones };
    private LinkResponse ReturnLinkedDrones(IEnumerable<DroneDTO> dronesDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedDrones)
    {
        var droneDTOList = dronesDTO.ToList();
        for (var index = 0; index < droneDTOList.Count(); index++)
        {
            var droneLinks = CreateLinksForDrone(httpContext, productId,
           droneDTOList[index].Id, fields);
            shapedDrones[index].Add("Links", droneLinks);
        }
        var droneCollection = new LinkCollectionWrapper<Entity>(shapedDrones);
        var linkedDrones = CreateLinksForDrones(httpContext, droneCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedDrones };
    }

    private List<Link> CreateLinksForDrone(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetDroneForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteDroneForProduct", values: new { productId, id }),
            "delete_drone",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateDroneForProduct", values: new { productId, id }),
            "update_drone",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateDroneForProduct", values: new { productId, id }),
            "partially_update_drone",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForDrones(HttpContext httpContext,
        LinkCollectionWrapper<Entity> dronesWrapper)
    {
        dronesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetDroneForProduct", values: new { }),
                "self",
                "GET"));

        return dronesWrapper;
    }
}
