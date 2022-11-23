using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Contracts.ITech.ITech_Gaming;

public interface IGamingLaptopRepository
{
    IEnumerable<GamingLaptop> GetGamingLaptops(Guid productId, bool trackChanges);

    GamingLaptop GetGamingLaptop(Guid productId, Guid id, bool trackChanges);

    void CreateGamingLaptopForProduct(Guid productId, GamingLaptop gamingLaptop);

    void DeleteGamingLaptop(GamingLaptop gamingLaptop);
}
