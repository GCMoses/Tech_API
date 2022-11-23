using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PC;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PC;

public class DesktopRepository : RepositoryBase<Desktop>, IDesktopRepository
{
    public DesktopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<Desktop> GetDesktops(Guid productId, bool trackChanges) =>
         FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        .OrderBy(p => p.Name)
        .ToList();


    public Desktop GetDesktop(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateDesktopForProduct(Guid productId, Desktop desktop)
    {
        desktop.ProductId = productId;
        Create(desktop);

    }

        public void DeleteDesktop(Desktop desktop) => Delete(desktop);
}