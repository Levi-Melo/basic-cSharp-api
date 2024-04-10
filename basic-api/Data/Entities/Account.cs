using basic_api.Data.Entities.Base;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Data.Entities
{
    public interface IAccount : IBaseEntity
    {
        string Name { get; set; }

        string Document { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string Phone { get; set; }

        RoleModel Role { get; set; }

        IEnumerable<BookModel> ReservedBooks { get; set; }
    }
}
