using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibStorj.Wrapper.Contracts.Models;
using LibStorj.Wrapper.Contracts.Exceptions;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class GetChildrenCallbackAsync : TaskCompletionSource<List<File>>, io.storj.libstorj.ListFilesCallback
    {
        public GetChildrenCallbackAsync(Bucket bucket, io.storj.libstorj.Storj storj)
        {
            storj.getChildren(new io.storj.libstorj.Bucket(bucket.Id, bucket.Name, bucket.Created, bucket.IsDecrypted), this);
        }

        public GetChildrenCallbackAsync(File file, io.storj.libstorj.Storj storj)
        {
            storj.getChildren(new io.storj.libstorj.File(file.Id,file.BucketId,file.Name,file.Created,file.IsDecrypted,file.Size,file.MimeType,file.Erasure,file.Index,file.Hmac), this);
        }

        public void onFilesReceived(string bucketId, io.storj.libstorj.File[] javaFiles)
        {
            List<File> files = new List<File>();
            foreach(var f in javaFiles)
            {
                files.Add(new File(f.getId(), f.getBucketId(), f.getName(), f.getCreated(), f.isDecrypted(), f.getSize(), f.getMimeType(), f.getErasure(), f.getIndex(), f.getHMAC(), f.getFileName(), f.isDirectory()));
            }
            SetResult(files);
        }

        public void onError(string bucketId, int errorCode, string errorMessage)
        {
            SetException(new ListFilesFailedException(bucketId, errorCode, errorMessage));
        }
    }
}
