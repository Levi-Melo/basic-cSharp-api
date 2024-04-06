namespace basic_api.Domain.Entities
{
    public interface ISoftDeletable
    {
        bool deleted { get; set; }
    }
}
