using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.NetworkingTechParams;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_Contracts.ITech.ITech_PC;

public interface ILaptopRepository
{
    Task<PagedList<Laptop>> GetLaptopsAsync(Guid productId, LaptopParams laptopParams, bool trackChanges);

    Task<Laptop> GetLaptopAsync(Guid productId, Guid id, bool trackChanges);
    void CreateLaptopForProduct(Guid productId, Laptop laptop);

    void DeleteLaptop(Laptop laptop);
}
