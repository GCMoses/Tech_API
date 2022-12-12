using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDevicesParams;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using ComputerTechAPI_Repository.Extensions.SmartDevicesExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_SmartDevices;

public class SmartPhoneRepository : RepositoryBase<SmartPhone>, ISmartPhoneRepository
{
    public SmartPhoneRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<SmartPhone>> GetSmartPhonesAsync(Guid productId,
             SmartPhoneParams smartPhoneParams, bool trackChanges)
    {
        var smartPhone = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterSmartPhones(smartPhoneParams.MinRating, smartPhoneParams.MaxRating)
        .Search(smartPhoneParams.SearchTerm)
        //.Sort(smartPhoneParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<SmartPhone>(smartPhone, count,
        smartPhoneParams.PageNumber, smartPhoneParams.PageSize);
    }


    public async Task<SmartPhone> GetSmartPhoneAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(s => s.ProductId.Equals(productId) && s.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateSmartPhoneForProduct(Guid productId, SmartPhone smartPhone)
    {
        smartPhone.ProductId = productId;
        Create(smartPhone);
    }


    public void DeleteSmartPhone(SmartPhone smartPhone) => Delete(smartPhone);


}
