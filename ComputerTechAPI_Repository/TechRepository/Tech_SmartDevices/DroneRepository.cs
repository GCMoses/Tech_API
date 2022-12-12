using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using ComputerTechAPI_Repository.Extensions.SmartDevicesExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_SmartDevices;

public class DroneRepository : RepositoryBase<Drone>, IDroneRepository
{
    public DroneRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public async Task<PagedList<Drone>> GetDronesAsync(Guid productId,
             DroneParams droneParams, bool trackChanges)
    {
        var drone = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterDrones(droneParams.MinRating, droneParams.MaxRating)
        .Search(droneParams.SearchTerm)
        //.Sort(droneParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<Drone>(drone, count,
        droneParams.PageNumber, droneParams.PageSize);
    }

    public async Task<Drone> GetDroneAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(s => s.ProductId.Equals(productId) && s.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateDroneForProduct(Guid productId, Drone drone)
    {
        drone.ProductId = productId;
        Create(drone);
    }

    public void DeleteDrone(Drone drone) => Delete(drone);
}
