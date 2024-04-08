using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface IStock : IBaseEntity
    {
        IBook Item { get; set; }
           
        ILocation? Location { get; set; }

        bool Reserved { get; set; }
    }
}
