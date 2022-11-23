﻿using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;

namespace ComputerTechAPI_Contracts.ITech.ITech_SmartDevices;

public interface IDroneRepository
{
    IEnumerable<Drone> GetDrones(Guid productId, bool trackChanges);

    Drone GetDrone(Guid productId, Guid id, bool trackChanges);

    void CreateDroneForProduct(Guid productId, Drone drone);

    void DeleteDrone(Drone drone);
}
