using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IPCLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.PCUtilities;

public class LaptopLinks : ILaptopLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<LaptopDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public LaptopLinks(LinkGenerator linkGenerator, IDataShaper<LaptopDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<LaptopDTO> laptopDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedLaptops = ShapeData(laptopDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedLaptops(laptopDTO, fields, productId, httpContext, shapedLaptops);

        return ReturnShapedLaptops(shapedLaptops);
    }



    private List<Entity> ShapeData(IEnumerable<LaptopDTO> laptopsDTO, string fields) => _dataShaper.ShapeData(laptopsDTO, fields)
            .Select(p => p.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedLaptops(List<Entity> shapedLaptops) =>
        new LinkResponse { ShapedEntities = shapedLaptops };

    private LinkResponse ReturnLinkedLaptops(IEnumerable<LaptopDTO> laptopsDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedLaptops)
    {
        var laptopDTOList = laptopsDTO.ToList();
        for (var index = 0; index < laptopDTOList.Count(); index++)
        {
            var laptopLinks = CreateLinksForLaptop(httpContext, productId,
           laptopDTOList[index].Id, fields);
            shapedLaptops[index].Add("Links", laptopLinks);
        }
        var laptopCollection = new LinkCollectionWrapper<Entity>(shapedLaptops);
        var linkedLaptops = CreateLinksForLaptops(httpContext, laptopCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedLaptops };
    }

    private List<Link> CreateLinksForLaptop(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetLaptopForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteLaptopForProduct", values: new { productId, id }),
            "delete_laptop",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateLaptopForProduct", values: new { productId, id }),
            "update_laptop",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateLaptopForProduct", values: new { productId, id }),
            "partially_update_laptop",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForLaptops(HttpContext httpContext,
        LinkCollectionWrapper<Entity> laptopsWrapper)
    {
        laptopsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetLaptopForProduct", values: new { }),
                "self",
                "GET"));

        return laptopsWrapper;
    }
}
