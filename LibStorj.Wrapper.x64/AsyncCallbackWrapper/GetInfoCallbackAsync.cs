using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class GetInfoCallbackAsync : TaskCompletionSource<Info>, io.storj.libstorj.GetInfoCallback
    {
        public GetInfoCallbackAsync(io.storj.libstorj.Storj storj)
        {
            storj.getInfo(this);
        }

        public void onInfoReceived(string str1, string str2, string str3, string str4)
        {
            Info result = new Info(str1, str2, str3, str4);
            SetResult(result);
        }

        public void onError(int i, string str)
        {
            SetException(new GetInfoFailedException(i, str));
        }
    }
}
