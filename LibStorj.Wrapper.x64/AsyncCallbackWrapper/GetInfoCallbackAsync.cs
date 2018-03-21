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

        public void onInfoReceived(string title, string description, string version, string host)
        {
            Info result = new Info(title, description, version, host);
            SetResult(result);
        }

        public void onError(int code, string message)
        {
            SetException(new GetInfoFailedException(code, message));
        }
    }
}
