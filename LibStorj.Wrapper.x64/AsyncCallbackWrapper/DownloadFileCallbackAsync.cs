using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class DownloadFileCallbackAsync:io.storj.libstorj.DownloadFileCallback
    {
        private DownloadJob _job;

        public static DownloadJob DownloadFile(string bucketId, string fileId, string localPath, io.storj.libstorj.Storj storj)
        {
            DownloadJob job = new DownloadJob(fileId);
            DownloadFileCallbackAsync callback = new DownloadFileCallbackAsync(job);
            try
            {
                
                var handle = storj.downloadFile(bucketId, fileId, localPath, callback);
                job.Id = handle;
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
            return job;
        }

        public DownloadFileCallbackAsync(DownloadJob job)
        {
            _job = job;
        }

        public void onProgress(string fileId, double progress, long downloadedBytes, long totalBytes)
        {
            _job.CurrentProgress = new ProgressStatusDownload(fileId, progress, downloadedBytes, totalBytes);
        }

        public void onComplete(string fileId, string localPath)
        {
             _job.CurrentProgress = new ProgressStatusDownload(fileId, 100, 0, 0);
            _job.IsFinished = true;
        }

        public void onError(string fileId, int errorCode, string message)
        {
            _job.IsOnError = true;
            //Todo: fehlermeldung übernehmen
        }
    }
}
