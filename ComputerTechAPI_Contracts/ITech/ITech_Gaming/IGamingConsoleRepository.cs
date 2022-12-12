using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Contracts.ITech.ITech_Gaming;

public interface IGamingConsoleRepository
{
    Task<PagedList<GamingConsole>> GetGamingConsolesAsync(Guid productId,
       GamingConsoleParams gamingConsoleParams, bool trackChanges);

    Task<GamingConsole> GetGamingConsoleAsync(Guid productId, Guid id, bool trackChanges);


    void CreateGamingConsoleForProduct(Guid productId, GamingConsole gamingConsole);

    void DeleteGamingConsole(GamingConsole gamingConsole);

}
