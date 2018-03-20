using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class GetFileCallbackAsync : TaskCompletionSource<File>, io.storj.libstorj.GetFileCallback
    {
        public GetFileCallbackAsync(string bucketId, string fileId, io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.getFile(bucketId, fileId, this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onFileReceived(io.storj.libstorj.File f)
        {
            File file = new File(f.getId(), f.getBucketId(), f.getName(), f.getCreated(), f.isDecrypted(), f.getSize(), f.getMimeType(), f.getErasure(), f.getIndex(), f.getHMAC());
            SetResult(file);
        }

        public void onError(int i, string str)
        {
            SetException(new GetFileFailedException(i, str));
        }
    }
}
