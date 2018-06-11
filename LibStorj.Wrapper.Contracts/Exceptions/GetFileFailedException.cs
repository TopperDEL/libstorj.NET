namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GetFileFailedException : GenericException
    {
        public string FileId { get; private set; }
        public GetFileFailedException(string fileId, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            FileId = fileId;
        }
    }
}
