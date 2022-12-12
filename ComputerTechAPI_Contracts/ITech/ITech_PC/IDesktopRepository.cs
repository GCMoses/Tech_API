using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_Contracts.ITech.ITech_PC;

public interface IDesktopRepository
{
    Task<PagedList<Desktop>> GetDesktopsAsync(Guid productId, DesktopParams desktopParams, bool trackChanges);

    Task<Desktop> GetDesktopAsync(Guid productId, Guid id, bool trackChanges);

    void CreateDesktopForProduct(Guid productId, Desktop desktop);

    void DeleteDesktop(Desktop desktop);
}
