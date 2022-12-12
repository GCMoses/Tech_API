using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTechAPI_Contracts;

public interface IDataShaper<T>
{
    IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString);
    ShapedEntity ShapeData(T entity, string fieldsString);
}
