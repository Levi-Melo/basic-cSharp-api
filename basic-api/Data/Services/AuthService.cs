namespace basic_api.Data.Services
{
    public interface IAuthService<T>
    {
        string SignIn(T content);

        T Verify(string token);
    }
}
