using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Repository.TechRepository.Tech_SmartDevices;

public class DroneRepository : RepositoryBase<Drone>, IDroneRepository
{
    public DroneRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public IEnumerable<Drone> GetDrones(Guid productId, bool trackChanges) =>
       FindByCondition(s => s.ProductId.Equals(productId), trackChanges)
      .OrderBy(s => s.Name)
      .ToList();


    public Drone GetDrone(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(s => s.ProductId.Equals(productId) && s.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateDroneForProduct(Guid productId, Drone drone)
    {
        drone.ProductId = productId;
        Create(drone);
    }

    public void DeleteDrone(Drone drone) => Delete(drone);
}
