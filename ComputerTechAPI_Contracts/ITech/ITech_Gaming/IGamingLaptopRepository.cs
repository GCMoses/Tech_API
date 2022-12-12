using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Contracts.ITech.ITech_Gaming;

public interface IGamingLaptopRepository
{
    Task<PagedList<GamingLaptop>> GetGamingLaptopsAsync(Guid productId,
        GamingLaptopParams gamingLaptopParams, bool trackChanges);

    Task<GamingLaptop> GetGamingLaptopAsync(Guid productId, Guid id, bool trackChanges);

    void CreateGamingLaptopForProduct(Guid productId, GamingLaptop gamingLaptop);

    void DeleteGamingLaptop(GamingLaptop gamingLaptop);
}
