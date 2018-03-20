using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class UploadFileCallbackAsync : TaskCompletionSource<File>, io.storj.libstorj.UploadFileCallback
    {
        private IProgress<ProgressStatusUpload> _progress;

        public UploadFileCallbackAsync(string bucketId, string fileName, string localPath, IProgress<ProgressStatusUpload> progress, io.storj.libstorj.Storj storj)
        {
            _progress = progress;
            try
            {
                storj.uploadFile(bucketId, fileName, localPath, this); //ToDo: CancelHandle
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onProgress(string filePath, double progress, long downloadedBytes, long totalBytes)
        {
            if (_progress != null)
                _progress.Report(new ProgressStatusUpload(filePath, progress, downloadedBytes, totalBytes));
        }

        public void onComplete(string str, io.storj.libstorj.File f)
        {
            File file = new File(f.getId(), f.getBucketId(), f.getName(), f.getCreated(), f.isDecrypted(), f.getSize(), f.getMimeType(), f.getErasure(), f.getIndex(), f.getHMAC());
            SetResult(file);
        }

        public void onError(string filePath, int errorCode, string message)
        {
            SetException(new UploadFileFailedException(filePath, errorCode, message));
        }
    }
}
