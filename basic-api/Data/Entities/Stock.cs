using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IStock : IBaseEntity
    {
        IBook item { get; set; }
           
        ILocation? location { get; set; }

        bool reserved { get; set; }
    }
}
