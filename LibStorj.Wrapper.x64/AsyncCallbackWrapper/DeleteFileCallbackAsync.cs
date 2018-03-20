using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class DeleteFileCallbackAsync : TaskCompletionSource<bool>, io.storj.libstorj.DeleteFileCallback
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

        public void onFileDeleted()
        {
            SetResult(true);
        }

        public void onError(int i, string str)
        {
            SetResult(false);
        }
    }
}
