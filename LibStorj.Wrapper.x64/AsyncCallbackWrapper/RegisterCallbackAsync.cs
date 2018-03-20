using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    class RegisterCallbackAsync : TaskCompletionSource<string>, io.storj.libstorj.RegisterCallback
    {
        public RegisterCallbackAsync(string user, string password, io.storj.libstorj.Storj storj)
        {
            storj.register(user, password, this);
        }

        public void onConfirmationPending(string str)
        {
            SetResult(str);
        }

        public void onError(int i, string str)
        {
            SetException(new RegisterFailedException(i, str));
        }
    }
}
