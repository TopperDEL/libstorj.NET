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
    /// Lists all files within a bucket - regardless of the file is a file or a directory.
    /// Use GetChildren to get only the real children of a bucket or a directory.
    /// </summary>
    class ListFilesCallbackAsync : TaskCompletionSource<Tuple<string,List<File>>>, io.storj.libstorj.ListFilesCallback
    {
        public ListFilesCallbackAsync(string bucketId, io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.listFiles(bucketId, this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onFilesReceived(string bucketId, io.storj.libstorj.File[] farr)
        {
            List<File> result = new List<File>();
            foreach (var f in farr)
            {
                File file = new File(f.getId(), f.getBucketId(), f.getName(), f.getCreated(), f.isDecrypted(), f.getSize(), f.getMimeType(), f.getErasure(), f.getIndex(), f.getHMAC(), f.getFileName(), f.isDirectory());
                result.Add(file);
            }

            SetResult(new Tuple<string, List<File>>(bucketId, result));
        }

        public void onError(string bucketId, int code, string message)
        {
            SetException(new ListFilesFailedException(bucketId, code, message));
        }
    }
}
