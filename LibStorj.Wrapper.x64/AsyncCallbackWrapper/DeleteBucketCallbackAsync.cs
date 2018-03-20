using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class DeleteBucketCallbackAsync : TaskCompletionSource<bool>, io.storj.libstorj.DeleteBucketCallback
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

        public void onBucketDeleted()
        {
            SetResult(true);
        }

        public void onError(int i, string str)
        {
            SetResult(false);
        }
    }
}
