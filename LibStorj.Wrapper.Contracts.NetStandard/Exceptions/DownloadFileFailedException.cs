﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class DownloadFileFailedException : GenericException
    {
        public string FileId { get; private set; }

        public DownloadFileFailedException(string fileId, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            FileId = fileId;
        }
    }
}
