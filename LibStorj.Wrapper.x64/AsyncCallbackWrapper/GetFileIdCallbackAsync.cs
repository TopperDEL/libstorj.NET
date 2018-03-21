using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class GetFileIdCallbackAsync : TaskCompletionSource<Tuple<string,string>>, io.storj.libstorj.GetFileIdCallback
    {
        public GetFileIdCallbackAsync(string bucketId, string fileName, io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.getFileId(bucketId, fileName, this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onFileIdReceived(string fileName, string fileId)
        {
            SetResult(new Tuple<string, string>(fileName, fileId));   
        }

        public void onError(string fileName, int code, string message)
        {
            SetException(new GetFileIdFailedException(fileName, code, message));
        }
    }
}
