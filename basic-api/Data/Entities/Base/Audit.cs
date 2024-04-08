namespace basic_api.Data.Entities.Base
{
    public interface IAudit
    {
        Guid Created_id { get; set; }

        DateTime Created_at { get; set; }

        List<Guid>? Updated_id { get; set; }

        DateTime? Updated_at { get; set; }

        List<Guid>? Deleted_id { get; set; }

        DateTime? Deleted_at { get; set; }
    }
}
