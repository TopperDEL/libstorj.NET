using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class GetBucketCallbackAsync : TaskCompletionSource<Bucket>, io.storj.libstorj.GetBucketCallback
    {
        public GetBucketCallbackAsync(string bucketId, io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.getBucket(bucketId, this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onBucketReceived(io.storj.libstorj.Bucket b)
        {
            Bucket bucket = new Bucket(b.getId(), b.getName(), b.getCreated(), b.isDecrypted());
            SetResult(bucket);
        }

        public void onError(string bucketId, int code, string message)
        {
            SetException(new GetBucketFailedException(bucketId, code, message));
        }
    }
}
