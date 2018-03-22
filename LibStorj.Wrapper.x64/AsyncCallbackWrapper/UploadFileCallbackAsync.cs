using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class UploadFileCallbackAsync : io.storj.libstorj.UploadFileCallback
    {
        private UploadJob _job;

        public static UploadJob UploadFile(string bucketId, string fileName, string localPath, io.storj.libstorj.Storj storj)
        {
            UploadJob job = new UploadJob(fileName);
            UploadFileCallbackAsync callback = new UploadFileCallbackAsync(job);
            try
            {

                var handle = storj.uploadFile(bucketId, fileName, localPath, callback);
                job.Id = handle;
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
            return job;
        }

        private UploadFileCallbackAsync(UploadJob job)
        {
            _job = job;
        }

        public void onProgress(string filePath, double progress, long uploadedBytes, long totalBytes)
        {
            _job.CurrentProgress = new ProgressStatusUpload(filePath, progress, uploadedBytes, totalBytes);
            _job.RaiseProgressChanged();
        }

        public void onComplete(string filePath, io.storj.libstorj.File f)
        {
            _job.CurrentProgress = new ProgressStatusUpload(filePath, 100, f.getSize(), f.getSize());
            _job.IsFinished = true;
            _job.RaiseJobFinished();
        }

        public void onError(string filePath, int errorCode, string message)
        {
            _job.IsOnError = true;
            _job.ErrorCode = errorCode;
            _job.ErrorMessage = message;
            _job.RaiseJobFailed();
        }
    }
}
