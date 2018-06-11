using System;

namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GenericException : Exception
    {
        public string ErrorMessage { get; private set; }
        public int ErrorCode { get; private set; }

        public GenericException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}
