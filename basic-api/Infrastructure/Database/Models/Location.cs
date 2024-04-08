using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models;

public class LocationModel : BaseEntity, ILocation
{ 
    public string name { get; set; }

    public object metadata { get; set; }

    public IEnumerable<IBook> books { get; set; }
}
