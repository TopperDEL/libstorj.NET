using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class DeleteBucketCallbackAsync : TaskCompletionSource<string>, io.storj.libstorj.DeleteBucketCallback
    {
        public DeleteBucketCallbackAsync(string bucketId, io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.deleteBucket(bucketId, this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onBucketDeleted(string bucketId)
        {
            SetResult(bucketId);
        }

        public void onError(string bucketId, int code, string message)
        {
            SetException(new LibStorj.Wrapper.Contracts.Exceptions.DeleteBucketFailedException(bucketId, code, message));
        }
    }
}
