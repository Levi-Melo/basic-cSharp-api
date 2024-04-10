namespace basic_api.Domain.Book.UseCases
{
    public interface IBookUpdateUseCase
    {
        bool Execute(string bookId, string userId);
    }
}
