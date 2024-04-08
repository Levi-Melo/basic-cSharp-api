using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models;

public class LocationModel : BaseEntity, ILocation
{ 
    public string Name { get; set; }

    public object Metadata { get; set; }

    public IEnumerable<IBook> Books { get; set; }
}
