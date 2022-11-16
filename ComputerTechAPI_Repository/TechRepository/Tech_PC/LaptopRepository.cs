using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PC;

public class LaptopRepository : RepositoryBase<Laptop>, ILaptopRepository
{
    public LaptopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}