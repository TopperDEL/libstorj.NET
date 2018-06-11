namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class DeleteFileFailedException : GenericException
    {
        public string FileId { get; private set; }
        public DeleteFileFailedException(string fileId, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            FileId = fileId;
        }
    }
}
