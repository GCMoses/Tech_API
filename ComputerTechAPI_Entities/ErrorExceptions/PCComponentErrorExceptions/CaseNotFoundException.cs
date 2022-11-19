namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class CaseNotFoundException : NotFoundException
{
    public CaseNotFoundException(Guid caseId) : base($"The case with id: {caseId} doesn't exist in the database.")
    {
    }
}

