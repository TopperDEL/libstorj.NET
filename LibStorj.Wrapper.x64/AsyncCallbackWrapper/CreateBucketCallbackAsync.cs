using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    /// <summary>
    /// The callback for the bucket-creation.
    /// </summary>
    class CreateBucketCallbackAsync : TaskCompletionSource<Bucket>, io.storj.libstorj.CreateBucketCallback
    {
        /// <summary>
        /// Starts the creation of a bucket.
        /// Throws KeysNotFoundException.
        /// </summary>
        /// <param name="bucketName">The name of the bucket to create</param>
        /// <param name="storj">The storj-object</param>
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

        /// <summary>
        /// Gets called if the bucket-creation was successfull
        /// </summary>
        /// <param name="b">The created bucket</param>
        public void onBucketCreated(io.storj.libstorj.Bucket b)
        {
            SetResult(new Bucket(b.getId(), b.getName(), b.getCreated(), b.isDecrypted()));
        }

        /// <summary>
        /// Gets called if the bucket-creation failed
        /// </summary>
        /// <param name="bucketName">The bucketName that failed</param>
        /// <param name="code">The error-code</param>
        /// <param name="message">The error-message</param>
        public void onError(string bucketName, int code, string message)
        {
            SetException(new CreateBucketFailedException(bucketName, code, message));
        }
    }
}
