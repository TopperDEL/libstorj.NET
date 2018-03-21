using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class DeleteFileCallbackAsync : TaskCompletionSource<string>, io.storj.libstorj.DeleteFileCallback
    {
        public DeleteFileCallbackAsync(string bucketId, string fileId, io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.deleteFile(bucketId, fileId, this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onFileDeleted(string fileId)
        {
            SetResult(fileId);
        }

        public void onError(string fileId, int code, string message)
        {
            SetException(new LibStorj.Wrapper.Contracts.Exceptions.DeleteFileFailedException(fileId, code, message));
        }
    }
}
