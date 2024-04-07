namespace basic_api.Data.Entities.Base
{
    public interface ISoftDeletable
    {
        bool deleted { get; set; }
    }
}
