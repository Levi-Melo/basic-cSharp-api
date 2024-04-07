using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface ILocation: IBaseEntity 
    { 
        string name { get; set; }

        object metadata { get; set; }

        IEnumerable<IBook> books { get; set; }
    }
}
