using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GetFileIdFailedException : GenericException
    {
        public GetFileIdFailedException(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
    }
}
