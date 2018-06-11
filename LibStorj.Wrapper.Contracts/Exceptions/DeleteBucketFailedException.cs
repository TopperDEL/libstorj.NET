namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class DeleteBucketFailedException : GenericException
    {
        public string BucketId { get; private set; }
        public DeleteBucketFailedException(string bucketId, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            BucketId = bucketId;
        }
    }
}
