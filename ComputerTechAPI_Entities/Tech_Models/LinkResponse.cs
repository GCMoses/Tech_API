using ComputerTechAPI_Entities.LinkModels;

namespace ComputerTechAPI_Entities.Tech_Models;

public class LinkResponse
{
    public bool HasLinks { get; set; }

    public List<Entity> ShapedEntities { get; set; }

    public LinkCollectionWrapper<Entity> LinkedEntities { get; set; }

    public LinkResponse()
    {
        LinkedEntities = new LinkCollectionWrapper<Entity>();
        ShapedEntities = new List<Entity>();
    }
}

