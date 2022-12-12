using ComputerTechAPI_Contracts.ITech.ITech_PCComponents;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Repository.Extensions.PCComponentExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PCComponents;

public class MotherboardRepository : RepositoryBase<Motherboard>, IMotherboardRepository
{
    public MotherboardRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public async Task<PagedList<Motherboard>> GetMotherboardsAsync(Guid productId,
               MotherboardParams motherboardParams, bool trackChanges)
    {
        var motherboard = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
        //.FilterMotherboards(motherboardParams.MinRating, motherboardParams.MaxRating)
        .Search(motherboardParams.SearchTerm)
        //.Sort(motherboardParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<Motherboard>(motherboard, count,
        motherboardParams.PageNumber, motherboardParams.PageSize);
    }

    public async Task<Motherboard> GetMotherboardAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateMotherboardForProduct(Guid productId, Motherboard motherboard)
    {
        motherboard.ProductId = productId;
        Create(motherboard);
    }

    public void DeleteMotherboard(Motherboard motherboard) => Delete(motherboard);
}