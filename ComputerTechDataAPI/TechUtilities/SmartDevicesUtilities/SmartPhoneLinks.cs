using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.ISMartDevicesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_Entities.LinkModels;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.Net.Http.Headers;

namespace ComputerTechDataAPI.TechUtilities.SmartDevicesUtilities;

public class SmartPhoneLinks : ISmartPhoneLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<SmartPhoneDTO> _dataShaper;
    public Dictionary<string, MediaTypeHeaderValue> AcceptHeader { get; set; } = new Dictionary<string, MediaTypeHeaderValue>();
    public SmartPhoneLinks(LinkGenerator linkGenerator, IDataShaper<SmartPhoneDTO> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }



    public LinkResponse TryGenerateLinks(IEnumerable<SmartPhoneDTO> smartPhoneDTO, string fields, Guid productId, HttpContext httpContext)
    {
        var shapedSmartPhones = ShapeData(smartPhoneDTO, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedSmartPhones(smartPhoneDTO, fields, productId, httpContext, shapedSmartPhones);

        return ReturnShapedSmartPhones(shapedSmartPhones);
    }



    private List<Entity> ShapeData(IEnumerable<SmartPhoneDTO> smartPhonesDTO, string fields) => _dataShaper.ShapeData(smartPhonesDTO, fields)
            .Select(p => p.Entity)
            .ToList();
    
    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;

        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedSmartPhones(List<Entity> shapedSmartPhones) =>
        new LinkResponse { ShapedEntities = shapedSmartPhones };
    private LinkResponse ReturnLinkedSmartPhones(IEnumerable<SmartPhoneDTO> smartPhonesDTO,
        string fields, Guid productId, HttpContext httpContext, List<Entity> shapedSmartPhones)
    {
        var smartPhoneDTOList = smartPhonesDTO.ToList();
        for (var index = 0; index < smartPhoneDTOList.Count(); index++)
        {
            var smartPhoneLinks = CreateLinksForSmartPhone(httpContext, productId,
           smartPhoneDTOList[index].Id, fields);
            shapedSmartPhones[index].Add("Links", smartPhoneLinks);
        }
        var smartPhoneCollection = new LinkCollectionWrapper<Entity>(shapedSmartPhones);
        var linkedDrones = CreateLinksForSmartPhones(httpContext, smartPhoneCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedDrones };
    }

    private List<Link> CreateLinksForSmartPhone(HttpContext httpContext, Guid productId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetSmartPhoneForProduct", values: new { productId, id, fields }),
            "self",
            "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteSmartPhoneForProduct", values: new { productId, id }),
            "delete_smartPhone",
            "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateSmartPhoneForProduct", values: new { productId, id }),
            "update_smartPhone",
            "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateSmartPhoneForProduct", values: new { productId, id }),
            "partially_update_smartPhone",
            "PATCH")
        };
        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForSmartPhones(HttpContext httpContext,
        LinkCollectionWrapper<Entity> smartPhonesWrapper)
    {
        smartPhonesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetSmartPhoneForProduct", values: new { }),
                "self",
                "GET"));

        return smartPhonesWrapper;
    }
}
