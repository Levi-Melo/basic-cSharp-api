namespace basic_api.Data.Entities.Base
{
    public interface ISoftDeletable
    {
        bool Deleted { get; set; }
    }
}
