using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Contracts.ITech.ITech_PCComponents;

public interface ICaseRepository
{
    IEnumerable<Case> GetCases(Guid productId, bool trackChanges);

    Case GetCase(Guid productId, Guid id, bool trackChanges);

    void CreateCaseForProduct(Guid productId, Case pcCase);

    void DeleteCase(Case pcCase);
}
