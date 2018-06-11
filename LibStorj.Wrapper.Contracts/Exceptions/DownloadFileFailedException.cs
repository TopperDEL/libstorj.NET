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
