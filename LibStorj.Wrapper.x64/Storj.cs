using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStorj.Wrapper.AsyncCallbackWrapper;
using LibStorj.Wrapper.Contracts.Interfaces;
using LibStorj.Wrapper.Contracts.Models;

namespace LibStorj.Wrapper.x64
{
    public class Storj : IStorj
    {
        private io.storj.libstorj.Storj _storjJava;

        public Storj()
        {
            _storjJava = new io.storj.libstorj.Storj();
        }

        public Storj(Uri url)
        {
            _storjJava = new io.storj.libstorj.Storj(new java.net.URL(url.ToString()));
        }

        public Storj(string url)
        {
            _storjJava = new io.storj.libstorj.Storj(url);
        }

        public void SetConfigDir(string path)
        {
            _storjJava.setConfigDirectory(new java.io.File(path));
        }

        public void SetDownloadDirectory(string path)
        {
            _storjJava.setDownloadDirectory(new java.io.File(path));
        }

        public Task<string> RegisterAsync(string user, string password)
        {
            return new RegisterCallbackAsync(user, password, _storjJava).Task;
        }

        public Task<Info> GetInfoAsync()
        {
            return new GetInfoCallbackAsync(_storjJava).Task;
        }

        public Task<List<Bucket>> GetBucketsAsync()
        {
            return new GetBucketsCallbackAsync(_storjJava).Task;
        }

        public Task<Bucket> GetBucketAsync(string bucketId)
        {
            return new GetBucketCallbackAsync(bucketId, _storjJava).Task;
        }

        public Task<Bucket> CreateBucketAsync(string bucketName)
        {
            return new CreateBucketCallbackAsync(bucketName, _storjJava).Task;
        }

        public Task<string> DeleteBucketAsync(string bucketId)
        {
            return new DeleteBucketCallbackAsync(bucketId, _storjJava).Task;
        }

        public Task<string> DeleteBucketAsync(Bucket bucket)
        {
            return DeleteBucketAsync(bucket.Id);
        }

        public Task<Tuple<string,List<File>>> ListFilesAsync(string bucketId)
        {
            return new ListFilesCallbackAsync(bucketId, _storjJava).Task;
        }

        public Task<Tuple<string, List<File>>> ListFilesAsync(Bucket bucket)
        {
            return ListFilesAsync(bucket.Id);
        }

        public Task<File> GetFileAsync(string bucketId, string fileId)
        {
            return new GetFileCallbackAsync(bucketId, fileId, _storjJava).Task;
        }

        public Task<File> GetFileAsync(Bucket bucket, string fileId)
        {
            return GetFileAsync(bucket.Id, fileId);
        }

        public Task<Tuple<string,string>> GetFileIdAsync(string bucketId, string fileName)
        {
            return new GetFileIdCallbackAsync(bucketId, fileName, _storjJava).Task;
        }

        public Task<Tuple<string, string>> GetFileIdAsync(Bucket bucket, string fileName)
        {
            return GetFileIdAsync(bucket.Id, fileName);
        }

        public Task<string> DeleteFileAsync(string bucketId, string fileId)
        {
            return new DeleteFileCallbackAsync(bucketId, fileId, _storjJava).Task;
        }

        public Task<string> DeleteFileAsync(Bucket bucket, string fileId)
        {
            return DeleteFileAsync(bucket.Id, fileId);
        }

        public Task<string> DeleteFileAsync(File file)
        {
            return DeleteFileAsync(file.BucketId, file.Id);
        }

        public DownloadJob DownloadFile(File file, string localPath)
        {
            return DownloadFile(file.BucketId, file.Id, localPath);
        }

        public DownloadJob DownloadFile(Bucket bucket, string fileId, string localPath)
        {
            return DownloadFile(bucket.Id, fileId, localPath);
        }

        public DownloadJob DownloadFile(string bucketId, string fileId, string localPath)
        {
            return DownloadFileCallbackAsync.DownloadFile(bucketId, fileId, localPath, _storjJava);
        }

        public UploadJob UploadFile(Bucket bucket, string fileName, string localPath)
        {
            return UploadFile(bucket.Id, fileName, localPath);
        }

        public UploadJob UploadFile(string bucketId, string fileName, string localPath)
        {
            return UploadFileCallbackAsync.UploadFile(bucketId, fileName, localPath, _storjJava);
        }



        public bool ImportKeys(Keys keys, string passphrase)
        {
            io.storj.libstorj.Keys javaKeys = new io.storj.libstorj.Keys(keys.User, keys.Password, keys.Mnemonic);
            return _storjJava.importKeys(javaKeys, passphrase);
        }

        public bool VerifyKeys(Keys keys)
        {
            io.storj.libstorj.Keys javaKeys = new io.storj.libstorj.Keys(keys.User, keys.Password, keys.Mnemonic);

            return _storjJava.verifyKeys(javaKeys) == 0;
        }

        public bool DeleteKeys()
        {
            return _storjJava.deleteKeys();
        }

        public bool KeysExist
        {
            get
            {
                return _storjJava.keysExist();
            }
        }
    }
}
