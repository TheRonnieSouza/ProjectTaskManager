namespace Infrastructure.Storages
{
    public interface IStorageService
    {
        Task<bool> Upload(string container,string fileName, Stream stream);
        Task<List<string>> GetAllFiles(string container);

        Task<bool> Delete(string container, string fileName);
        Task<string> UrlGenerator(string container, string fileName);
    }
}
