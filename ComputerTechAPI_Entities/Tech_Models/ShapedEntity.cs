﻿namespace ComputerTechAPI_Entities.Tech_Models;

public class ShapedEntity
{
    public ShapedEntity()
    {
        Entity = new Entity();
    }

    public Guid Id { get; set; }
    public Entity Entity { get; set; }
}
