using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_Contracts.ITech.ITech_PC;

public interface ILaptopRepository
{
    IEnumerable<Laptop> GetLaptops(Guid productId, bool trackChanges);

    Laptop GetLaptop(Guid productId, Guid id, bool trackChanges);

    void CreateLaptopForProduct(Guid productId, Laptop laptop);

    void DeleteLaptop(Laptop laptop);
}
