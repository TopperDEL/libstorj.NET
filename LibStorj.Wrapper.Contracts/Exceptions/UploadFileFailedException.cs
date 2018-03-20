using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class UploadFileFailedException : GenericException
    {
        public string FilePath { get; private set; }

        public UploadFileFailedException(string filePath, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            FilePath = filePath;
        }
    }
}
