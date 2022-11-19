using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ICaseRepository
{
    IEnumerable<Case> GetCases(Guid productId, bool trackChanges);

    Case GetCase(Guid productId, Guid id, bool trackChanges);

    void CreateCase(Case pcCase);
}
