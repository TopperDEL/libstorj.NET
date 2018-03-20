using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Interfaces
{
    public interface IStorj
    {
        bool ImportKeys(Keys keys, string passphrase);
        bool VerifyKeys(Keys keys);
        bool DeleteKeys();
        bool KeysExist { get; }
        void SetConfigDir(string path);
        void SetDownloadDirectory(string path);

        Task<string> RegisterAsync(string user, string password);

        Task<Info> GetInfoAsync();
        Task<List<Bucket>> GetBucketsAsync();
        Task<Bucket> GetBucketAsync(string bucketId);
        Task<Bucket> CreateBucketAsync(string bucketName);
        Task<bool> DeleteBucketAsync(string bucketName);
        Task<bool> DeleteBucketAsync(Bucket bucket);
        Task<List<File>> ListFilesAsync(string bucketId);
        Task<List<File>> ListFilesAsync(Bucket bucket);
        Task<File> GetFileAsync(string bucketId, string fileId);
        Task<File> GetFileAsync(Bucket bucket, string fileId);
        Task<string> GetFileIdAsync(string bucketId, string fileName);
        Task<string> GetFileIdAsync(Bucket bucket, string fileName);
        Task<bool> DeleteFileAsync(string bucketId, string fileId);
        Task<bool> DeleteFileAsync(Bucket bucket, string fileId);
        Task<bool> DeleteFileAsync(File file);
        DownloadJob DownloadFile(File file, string localPath);
        DownloadJob DownloadFile(Bucket bucket, string fileId, string localPath);
        DownloadJob DownloadFile(string bucketId, string fileId, string localPath);
        Task<File> UploadFile(Bucket bucket, string fileName, string localPath, IProgress<ProgressStatusUpload> progress = null);
        Task<File> UploadFile(string bucketId, string fileName, string localPath, IProgress<ProgressStatusUpload> progress = null);
    }
}
