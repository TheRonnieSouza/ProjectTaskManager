
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using System.Net;

namespace Infrastructure.Storages
{
    public class S3Service : IStorageService
    {
        private readonly IAmazonS3 _client;
        public S3Service()
        {           
            _client = new AmazonS3Client(RegionEndpoint.USEast1);
        }
        public async Task<bool> Delete(string container, string fileName)
        {
            try
            {
                var request = new DeleteObjectRequest
                {
                    BucketName = container,
                    Key = fileName
                };

                var response = await _client.DeleteObjectAsync(request);

                return response.HttpStatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new AmazonServiceException(ex);
            }
        }

        public async Task<List<string>> GetAllFiles(string container)
        {
            try
            {
                var request = new ListObjectsV2Request
                {
                    BucketName = container,
                };

                var response = await _client.ListObjectsV2Async(request);

                return response.S3Objects.Select(x => x.Key).ToList();
            }
            catch (Exception ex)
            {
               throw new AmazonServiceException(ex);
            }           
        }

        public async Task<bool> Upload(string container, string fileName, Stream stream)
        {
            try
            {
                var request = new PutObjectRequest
                {
                    BucketName = container,
                    Key = fileName,
                    InputStream = stream
                };

                var response = await _client.PutObjectAsync(request);

                return response.HttpStatusCode == HttpStatusCode.OK;
             }
            catch (Exception ex)
            {
               throw new AmazonServiceException(ex);
            }
        }

        public async Task<string> UrlGenerator(string container, string fileName)
        {
            try
            {
                var request = new GetPreSignedUrlRequest()
                {
                    BucketName = container,
                    Key = fileName,
                    Expires = DateTime.UtcNow.AddMinutes(10)
                };

                var url = await _client.GetPreSignedURLAsync(request);

                return url;
            }
            catch (Exception ex)
            {
                throw new AmazonServiceException(ex);
            }
        }
    }
}
