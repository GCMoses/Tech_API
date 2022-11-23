﻿using ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using System.Text;

namespace ComputerTechAPI_Repository.TechRepository.Tech_SmartDevices;

public class SmartPhoneRepository : RepositoryBase<SmartPhone>, ISmartPhoneRepository
{
    public SmartPhoneRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public IEnumerable<SmartPhone> GetSmartPhones(Guid productId, bool trackChanges) =>
       FindByCondition(s => s.ProductId.Equals(productId), trackChanges)
      .OrderBy(s => s.Name)
      .ToList();


    public SmartPhone GetSmartPhone(Guid productId, Guid id, bool trackChanges) =>
        FindByCondition(s => s.ProductId.Equals(productId) && s.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateSmartPhoneForProduct(Guid productId, SmartPhone smartPhone)
    {
        smartPhone.ProductId = productId;
        Create(smartPhone);
    }


    public void DeleteSmartPhone(SmartPhone smartPhone) => Delete(smartPhone);
}
