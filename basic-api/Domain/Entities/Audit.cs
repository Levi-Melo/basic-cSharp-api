namespace basic_api.Domain.Entities
{
    public interface IAudit
    {
        Guid created_id { get; set; }

        DateTime created_at { get; set; }

        List<Guid>? updated_id { get; set; }

        DateTime? updated_at { get; set; }

        List<Guid>? deleted_id { get; set; }

        DateTime? deleted_at { get; set; }
    }
}
