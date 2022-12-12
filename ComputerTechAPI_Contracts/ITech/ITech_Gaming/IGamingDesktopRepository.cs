using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTechAPI_Contracts.ITech.ITech_Gaming;

public interface IGamingDesktopRepository
{
    Task<PagedList<GamingDesktop>> GetGamingDesktopsAsync(Guid productId,
        GamingDesktopParams gamingDesktopParams, bool trackChanges);

    Task<GamingDesktop> GetGamingDesktopAsync(Guid productId, Guid id, bool trackChanges);
    void CreateGamingDesktopForProduct(Guid productId, GamingDesktop gamingDesktop);

    void DeleteGamingDesktop(GamingDesktop gamingDesktop);
}
