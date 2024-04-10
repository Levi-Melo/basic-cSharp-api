using Amazon.S3;
using Amazon.S3.Model;
using basic_api.Data.Services;

namespace basic_api.Infrastructure.Service
{
    public class FileService(IAmazonS3 s3Client, string bucket, string directory) : IFileService
    {
        private readonly string _bucket = bucket;
        private readonly string _directory = directory;
        private readonly IAmazonS3 _s3Client = s3Client;

        public async Task<byte[]> DownloadAsync(string fileName, byte[] buffer)
        {
            var request = new GetObjectRequest()
            {
                BucketName = _bucket,
                Key = _directory + '/' + fileName
            };

            using GetObjectResponse response = await _s3Client.GetObjectAsync(request);
            using var memoryStream = new MemoryStream();
            
            await response.ResponseStream.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }

        public async Task<bool> UploadAsync(string fileName, byte[] buffer)
        {
            using var memoryStream = new MemoryStream(buffer);
            var request = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = _directory + '/' + fileName,
                InputStream = memoryStream
            };

            var response = await _s3Client.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Successfully uploaded {fileName} to {_bucket}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Could not upload {fileName} to {_bucket}.");
                return false;
            }
        }
    }
}
