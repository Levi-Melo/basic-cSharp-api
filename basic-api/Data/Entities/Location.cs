using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface ILocation: IBaseEntity 
    { 
        string Name { get; set; }

        object Metadata { get; set; }

        IEnumerable<IBook> Books { get; set; }
    }
}
