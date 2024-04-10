using basic_api.Data.Entities.Base;

namespace basic_api.Data.Entities
{
    public interface ITenant : IAudit, ISoftDeletable
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Document { get; set; }

        string ValidUntil { get; set; }

        string Email { get; set; }

        string Phone { get; set; }

        DateTime DueDate { get; set; }
    }
}
