using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class Stock : BaseEntity, IStock 
    {
        public IBook item { get; set; }
           
        public ILocation? location { get; set; }

        public bool reserved { get; set; }
    }
}
