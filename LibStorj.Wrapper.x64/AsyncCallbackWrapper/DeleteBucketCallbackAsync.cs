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
    /// The callback for the bucket-deletion
    /// </summary>
    class DeleteBucketCallbackAsync : TaskCompletionSource<string>, io.storj.libstorj.DeleteBucketCallback
    {
        /// <summary>
        /// Starts the deletion of a bucket.
        /// Throws KeysNotFoundException
        /// </summary>
        /// <param name="bucketId">The Id of the bucket to delete</param>
        /// <param name="storj">The storj-object</param>
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

        /// <summary>
        /// Gets called if the bucket-deletion was successfull
        /// </summary>
        /// <param name="bucketId">The bucketId that got deleted</param>
        public void onBucketDeleted(string bucketId)
        {
            SetResult(bucketId);
        }

        /// <summary>
        /// Gets called if the bucket-creation failed
        /// </summary>
        /// <param name="bucketId">The buckedId that failed</param>
        /// <param name="code">The error-code</param>
        /// <param name="message">The error-message</param>
        public void onError(string bucketId, int code, string message)
        {
            SetException(new LibStorj.Wrapper.Contracts.Exceptions.DeleteBucketFailedException(bucketId, code, message));
        }
    }
}
