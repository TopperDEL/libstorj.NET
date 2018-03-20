using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class GetBucketsCallbackAsync : TaskCompletionSource<List<Bucket>>, io.storj.libstorj.GetBucketsCallback
    {
        public GetBucketsCallbackAsync(io.storj.libstorj.Storj storj)
        {
            try
            {
                storj.getBuckets(this);
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onBucketsReceived(io.storj.libstorj.Bucket[] barr)
        {
            List<Bucket> result = new List<Bucket>();
            foreach(var b in barr)
            {
                Bucket bucket = new Bucket(b.getId(), b.getName(), b.getCreated(), b.isDecrypted());
                result.Add(bucket);
            }
            SetResult(result);
        }

        public void onError(int i, string str)
        {
            SetException(new GetBucketsFailedException(i, str));
        }
    }
}
