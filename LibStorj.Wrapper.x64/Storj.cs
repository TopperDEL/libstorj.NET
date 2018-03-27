using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStorj.Wrapper.AsyncCallbackWrapper;
using LibStorj.Wrapper.Contracts.Interfaces;
using LibStorj.Wrapper.Contracts.Models;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("LibStorj.Wrapper.Test")]
namespace LibStorj.Wrapper.x64
{
    /// <summary>
    /// This class provides access to the storj-network
    /// </summary>
    public class Storj : IStorj, IDisposable
    {
        private io.storj.libstorj.Storj _storjJava;

        /// <summary>
        /// Creates a storj-object with default connection parameters
        /// </summary>
        public Storj()
        {
            _storjJava = new io.storj.libstorj.Storj();
        }

        /// <summary>
        /// Creates a storj-object that connects to the given URL
        /// </summary>
        /// <param name="url">The URL to connect to</param>
        public Storj(Uri url)
        {
            _storjJava = new io.storj.libstorj.Storj(new java.net.URL(url.ToString()));
        }

        /// <summary>
        /// Creates a storj-object that connects to the given URL (as string)
        /// </summary>
        /// <param name="url">The URL to connect to</param>
        public Storj(string url)
        {
            _storjJava = new io.storj.libstorj.Storj(url);
        }

        /// <summary>
        /// Create a storj-object with the given storj-java-object.
        /// Used for unit-tests.
        /// </summary>
        /// <param name="storjJava">The storjJava-Object</param>
        internal Storj(io.storj.libstorj.Storj storjJava)
        {
            _storjJava = storjJava;
        }

        /// <summary>
        /// Sets the directory for the configuration file
        /// </summary>
        /// <param name="path">The path where to config should be placed</param>
        public void SetConfigDir(string path)
        {
            _storjJava.setConfigDirectory(new java.io.File(path));
        }

        /// <summary>
        /// Sets the download directory
        /// </summary>
        /// <param name="path">The download directory</param>
        public void SetDownloadDirectory(string path)
        {
            _storjJava.setDownloadDirectory(new java.io.File(path));
        }

        /// <summary>
        /// Registers a new user on the bridge.
        /// The method is async.
        /// </summary>
        /// <param name="user">The users email</param>
        /// <param name="password">The password</param>
        /// <returns>Returns the email where the activation link is sent to</returns>
        public Task<string> RegisterAsync(string user, string password)
        {
            return new RegisterCallbackAsync(user, password, _storjJava).Task;
        }

        /// <summary>
        /// Returns info about the bridge.
        /// The method is async.
        /// </summary>
        /// <returns>The info about the bridge</returns>
        public Task<Info> GetInfoAsync()
        {
            return new GetInfoCallbackAsync(_storjJava).Task;
        }

        /// <summary>
        /// Returns all buckets of the current account.
        /// The method is async.
        /// </summary>
        /// <returns>A list of buckets</returns>
        public Task<List<Bucket>> GetBucketsAsync()
        {
            return new GetBucketsCallbackAsync(_storjJava).Task;
        }

        /// <summary>
        /// Returns a specific bucket with the given bucketId.
        /// The method is async.
        /// </summary>
        /// <param name="bucketId">The bucketId to retrieve</param>
        /// <returns>The bucket if existing</returns>
        public Task<Bucket> GetBucketAsync(string bucketId)
        {
            return new GetBucketCallbackAsync(bucketId, _storjJava).Task;
        }

        /// <summary>
        /// Returns a specific bucket with the given bucketName.
        /// The method is async.
        /// </summary>
        /// <param name="bucketName">The bucketName to retrieve</param>
        /// <returns>The bucket if existing</returns>
        public Task<Bucket> CreateBucketAsync(string bucketName)
        {
            return new CreateBucketCallbackAsync(bucketName, _storjJava).Task;
        }

        /// <summary>
        /// Deletes a bucket via its Id.
        /// The method is async.
        /// </summary>
        /// <param name="bucketId">The bucketId to delete</param>
        /// <returns>The bucketId that got deleted</returns>
        public Task<string> DeleteBucketAsync(string bucketId)
        {
            return new DeleteBucketCallbackAsync(bucketId, _storjJava).Task;
        }

        /// <summary>
        /// Deletes a bucket via a bucket-object.
        /// The method is async.
        /// </summary>
        /// <param name="bucket">The bucket to delete</param>
        /// <returns>The bucketId that got deleted</returns>
        public Task<string> DeleteBucketAsync(Bucket bucket)
        {
            return DeleteBucketAsync(bucket.Id);
        }

        /// <summary>
        /// Lists all files within a bucket via a bucketId.
        /// The method is async.
        /// </summary>
        /// <param name="bucketId">The bucketID</param>
        /// <returns>The list of files within a bucket</returns>
        public Task<Tuple<string,List<File>>> ListFilesAsync(string bucketId)
        {
            return new ListFilesCallbackAsync(bucketId, _storjJava).Task;
        }

        /// <summary>
        /// Lists all files within a bucket via a bucket-object.
        /// The method is async.
        /// </summary>
        /// <param name="bucket">The bucket</param>
        /// <returns>The list of files within a bucket</returns>
        public Task<Tuple<string, List<File>>> ListFilesAsync(Bucket bucket)
        {
            return ListFilesAsync(bucket.Id);
        }

        /// <summary>
        /// Gets the file-info for a fileId within a bucket (via bucketId).
        /// The method is async.
        /// </summary>
        /// <param name="bucketId">The bucketId where the file is contained</param>
        /// <param name="fileId">The fileId to retrieve</param>
        /// <returns>Returns the file-info if existing</returns>
        public Task<File> GetFileAsync(string bucketId, string fileId)
        {
            return new GetFileCallbackAsync(bucketId, fileId, _storjJava).Task;
        }

        /// <summary>
        /// Gets the file-info for a fileId within a bucket (via bucket-object).
        /// The method is async.
        /// </summary>
        /// <param name="bucket">The bucket where the file is contained</param>
        /// <param name="fileId">The fileId to retrieve</param>
        /// <returns>Returns the file-info if existing</returns>
        public Task<File> GetFileAsync(Bucket bucket, string fileId)
        {
            return GetFileAsync(bucket.Id, fileId);
        }

        /// <summary>
        /// Gets the file-info for a fileName within a bucket (via bucketId).
        /// The method is async.
        /// </summary>
        /// <param name="bucketId">The bucketId where the file is contained</param>
        /// <param name="fileName">The fileName to retrieve</param>
        /// <returns>Returns the file-info if existing</returns>
        public Task<Tuple<string,string>> GetFileIdAsync(string bucketId, string fileName)
        {
            return new GetFileIdCallbackAsync(bucketId, fileName, _storjJava).Task;
        }

        /// <summary>
        /// Gets the file-info for a fileName within a bucket (via bucket-object)
        /// </summary>
        /// <param name="bucket">The bucket where the file is contained</param>
        /// <param name="fileName">The fileName to retrieve</param>
        /// <returns>Returns the file-info if existing</returns>
        public Task<Tuple<string, string>> GetFileIdAsync(Bucket bucket, string fileName)
        {
            return GetFileIdAsync(bucket.Id, fileName);
        }

        /// <summary>
        /// Deletes a file within a bucket (via bucketId and fileId).
        /// The method is async.
        /// </summary>
        /// <param name="bucketId">The bucketId where the file is contained</param>
        /// <param name="fileId">The fileId of the file to delete</param>
        /// <returns>The deleted fileId</returns>
        public Task<string> DeleteFileAsync(string bucketId, string fileId)
        {
            return new DeleteFileCallbackAsync(bucketId, fileId, _storjJava).Task;
        }

        /// <summary>
        /// Deletes a file within a bucket (via bucket-object and fileId).
        /// The method is async.
        /// </summary>
        /// <param name="bucket">The bucket where the file is contained</param>
        /// <param name="fileId">The fileId of the file to delete</param>
        /// <returns>The deleted fileId</returns>
        public Task<string> DeleteFileAsync(Bucket bucket, string fileId)
        {
            return DeleteFileAsync(bucket.Id, fileId);
        }

        /// <summary>
        /// Deletes a file.
        /// The method is async.
        /// </summary>
        /// <param name="file">The file to delete</param>
        /// <returns>The deleted fileId</returns>
        public Task<string> DeleteFileAsync(File file)
        {
            return DeleteFileAsync(file.BucketId, file.Id);
        }

        /// <summary>
        /// Downloads a file to the local path.
        /// It returns a DownloadJob, that informs about the current download-state.
        /// </summary>
        /// <param name="file">The file to download</param>
        /// <param name="localPath">The path where the file should be placed</param>
        /// <returns>A DownloadJob with info about the download-state</returns>
        public DownloadJob DownloadFile(File file, string localPath)
        {
            return DownloadFile(file.BucketId, file.Id, localPath);
        }
        
        /// <summary>
        /// Downloads a file to the local path.
        /// It returns a DownloadJob, that informs about the current download-state.
        /// </summary>
        /// <param name="bucket">The bucket where the file is contained</param>
        /// <param name="fileId">The fileId to download</param>
        /// <param name="localPath">The path where the file should be placed</param>
        /// <returns>A DownloadJob with info about the download-state</returns>
        public DownloadJob DownloadFile(Bucket bucket, string fileId, string localPath)
        {
            return DownloadFile(bucket.Id, fileId, localPath);
        }

        /// <summary>
        /// Download a file to the local path.
        /// It returns a DownloadJob, that informs about the current download-state.
        /// </summary>
        /// <param name="bucketId">The bucketId where the file is contained</param>
        /// <param name="fileId">The fileId to download</param>
        /// <param name="localPath">The path where the file should be placed</param>
        /// <returns>A DownloadJob with info about the download-state</returns>
        public DownloadJob DownloadFile(string bucketId, string fileId, string localPath)
        {
            return DownloadFileCallbackAsync.DownloadFile(bucketId, fileId, localPath, _storjJava);
        }

        /// <summary>
        /// Uploads a file from a given path.
        /// It returns an UploadJob, that informs about the current upload-state.
        /// </summary>
        /// <param name="bucket">The bucket where the file should be uploaded to</param>
        /// <param name="fileName">The name of the file to upload</param>
        /// <param name="localPath">The path to the file to upload</param>
        /// <returns>An UploadJob with info about the upload-state</returns>
        public UploadJob UploadFile(Bucket bucket, string fileName, string localPath)
        {
            return UploadFile(bucket.Id, fileName, localPath);
        }

        /// <summary>
        /// Uploads a file from a given path.
        /// It return an UploadJob, that informs about the current upload-state.
        /// </summary>
        /// <param name="bucketId">The bucketId where the file should be uploaded to</param>
        /// <param name="fileName">The name of the file to upload</param>
        /// <param name="localPath">The path to the file to upload</param>
        /// <returns>An UploadJob with info about the upload-state</returns>
        public UploadJob UploadFile(string bucketId, string fileName, string localPath)
        {
            return UploadFileCallbackAsync.UploadFile(bucketId, fileName, localPath, _storjJava);
        }

        /// <summary>
        /// Imports the given keys using the passphrase.
        /// </summary>
        /// <param name="keys">The keys to import</param>
        /// <param name="passphrase">The passphrase for the keys</param>
        /// <returns>True, if the import was successfull; false, if not</returns>
        public bool ImportKeys(Keys keys, string passphrase)
        {
            io.storj.libstorj.Keys javaKeys = new io.storj.libstorj.Keys(keys.User, keys.Password, keys.Mnemonic);
            return _storjJava.importKeys(javaKeys, passphrase);
        }

        /// <summary>
        /// Verifies the given keys.
        /// </summary>
        /// <param name="keys">The keys to verifiy</param>
        /// <returns>True, if the keys are valid; false, if not</returns>
        public bool VerifyKeys(Keys keys)
        {
            io.storj.libstorj.Keys javaKeys = new io.storj.libstorj.Keys(keys.User, keys.Password, keys.Mnemonic);

            return _storjJava.verifyKeys(javaKeys) == 0;
        }

        /// <summary>
        /// Deletes the keys from the local config.
        /// </summary>
        /// <returns>True, if the keys got deleted; false, if not</returns>
        public bool DeleteKeys()
        {
            return _storjJava.deleteKeys();
        }

        /// <summary>
        /// Disposes the storj-object
        /// </summary>
        public void Dispose()
        {
            _storjJava.destroy();
        }

        /// <summary>
        /// Cancels a download-job
        /// </summary>
        /// <param name="job">The job to cancel</param>
        /// <returns>True, if the job got cancelled; false if not</returns>
        public bool CancelDownload(DownloadJob job)
        {
            return _storjJava.cancelDownload(job.Id);
        }

        /// <summary>
        /// Cancels an upload-job
        /// </summary>
        /// <param name="job">The job to cancel</param>
        /// <returns>True, if the job got cancelled; false if not</returns>
        public bool CancelUpload(UploadJob job)
        {
            return _storjJava.cancelUpload(job.Id);
        }

        /// <summary>
        /// Checks if keys exist
        /// </summary>
        public bool KeysExist
        {
            get
            {
                return _storjJava.keysExist();
            }
        }
    }
}
