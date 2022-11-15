using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTech_Repository.TechRepository.Tech_PCComponents;

public class MotherboardRepository : RepositoryBase<Motherboard>, IMotherboardRepository
{
    public MotherboardRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}