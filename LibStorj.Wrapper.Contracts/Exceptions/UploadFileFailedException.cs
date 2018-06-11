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
