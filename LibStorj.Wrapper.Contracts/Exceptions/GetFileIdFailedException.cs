namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GetFileIdFailedException : GenericException
    {
        public string FileId { get; private set; }
        public GetFileIdFailedException(string fileId, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            FileId = fileId;
        }
    }
}
