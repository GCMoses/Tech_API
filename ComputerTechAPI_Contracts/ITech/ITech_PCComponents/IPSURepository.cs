using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface IPSURepository
{
    Task<PagedList<PSU>> GetPSUsAsync(Guid productId, PSUParams psuParams, bool trackChanges);

    Task<PSU> GetPSUAsync(Guid productId, Guid id, bool trackChanges);

    void CreatePSUForProduct(Guid productId, PSU psu);

    void DeletePSU(PSU psu);
}
