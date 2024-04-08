using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IGenre : IBaseEntity
    {
        string Name { get; set; }

        string Description { get; set; }
     
        IEnumerable<IBook> Books { get; set; }
    }
}
