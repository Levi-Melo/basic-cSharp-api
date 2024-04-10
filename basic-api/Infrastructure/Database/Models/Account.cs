using basic_api.Data.Entities;

namespace basic_api.Infrastructure.Database.Models
{
    public class AccountModel : BaseEntity, IAccount
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<BookModel> ReservedBooks { get; set; }
        public RoleModel Role { get; set; }
    }
}
