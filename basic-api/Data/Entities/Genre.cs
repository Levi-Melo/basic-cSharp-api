using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IGenre : IBaseEntity
    {
        string name { get; set; }

        string description { get; set; }
    }
}
