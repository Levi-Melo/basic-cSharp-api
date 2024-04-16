using basic_api.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace basic_api.Infrastructure.Database.Models
{
    public class AccountModel : BaseEntity, IAccount
    {

        public string Name { get; set; }

        public string Document { get; set; }
        
        [JsonIgnore]
        [Required]
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public RoleModel Role { get; set; }

        public IEnumerable<OrderModel>? Orders { get; set; }
    }
}
