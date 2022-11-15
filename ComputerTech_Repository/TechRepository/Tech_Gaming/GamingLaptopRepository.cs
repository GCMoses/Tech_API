using ComputerTechAPI_Contracts.ITech.ITech_Gaming;
using ComputerTechAPI_Entities.Tech_Models.Gaming;

namespace ComputerTech_Repository.TechRepository.Tech_Gaming;

public class GamingLaptopRepository : RepositoryBase<GamingLaptop>, IGamingLaptopRepository
{
    public GamingLaptopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}