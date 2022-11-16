using ComputerTechAPI_Contracts.ITech.ITech_Accessories;
using ComputerTechAPI_Entities.Tech_Models.Accessories;

namespace ComputerTechAPI_Repository.TechRepository.Tech_Accessories;

public class GamingKeyboardRepository : RepositoryBase<GamingKeyboard>, IGamingKeyboardRepository
{
    public GamingKeyboardRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
