using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class CreateBucketFailedException : GenericException
    {
        public string BucketName { get; private set; }
        public CreateBucketFailedException(string bucketName, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            BucketName = bucketName;
        }
    }
}
