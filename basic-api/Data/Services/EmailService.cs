namespace basic_api.Data.Services
{
    public interface IEmailService
    {
        Task Send(string to, string subject, string body);
    }
}
