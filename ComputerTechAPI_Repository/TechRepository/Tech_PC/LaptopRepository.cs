using ComputerTechAPI_Contracts.ITech.ITech_PC;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Repository.Extensions.PCExtensions;
using Microsoft.EntityFrameworkCore;

namespace ComputerTechAPI_Repository.TechRepository.Tech_PC;

public class LaptopRepository : RepositoryBase<Laptop>, ILaptopRepository
{
    public LaptopRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<PagedList<Laptop>> GetLaptopsAsync(Guid productId,
                LaptopParams laptopParams, bool trackChanges)
    {
        var laptop = await FindByCondition(g => g.ProductId.Equals(productId), trackChanges)
        //.FilterLaptops(laptopParams.MinRating, laptopParams.MaxRating)
        .Search(laptopParams.SearchTerm)
        //.Sort(laptopParams.OrderBy)
        .ToListAsync();
        var count = await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).CountAsync();
        return new PagedList<Laptop>(laptop, count,
        laptopParams.PageNumber, laptopParams.PageSize);
    }


    public async Task<Laptop> GetLaptopAsync(Guid productId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateLaptopForProduct(Guid productId, Laptop laptop)
    {
        laptop.ProductId = productId;
        Create(laptop);
    }


    public void DeleteLaptop(Laptop laptop) => Delete(laptop);
}