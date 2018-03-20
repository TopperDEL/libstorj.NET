using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class CreateBucketCallbackAsync : TaskCompletionSource<Bucket>, io.storj.libstorj.CreateBucketCallback
    {
        public CreateBucketCallbackAsync(string bucketName, io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.createBucket(bucketName, this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onBucketCreated(io.storj.libstorj.Bucket b)
        {
            SetResult(new Bucket(b.getId(), b.getName(), b.getCreated(), b.isDecrypted()));
        }

        public void onError(int i, string str)
        {
            SetException(new GetBucketFailedException(i, str));
        }
    }
}
