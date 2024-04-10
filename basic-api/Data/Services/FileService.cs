namespace basic_api.Data.Services
{
    public interface IFileService
    {
        Task<bool> UploadAsync(string fileName, byte[] buffer);

        Task<byte[]> DownloadAsync(string fileName);

    }
}
