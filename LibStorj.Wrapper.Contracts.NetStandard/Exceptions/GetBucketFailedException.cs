using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GetBucketFailedException : GenericException
    {
        public GetBucketFailedException(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
    }
}
