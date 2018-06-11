namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GetBucketFailedException : GenericException
    {
        public string BucketId { get; private set; }
        public GetBucketFailedException(string bucketId, int errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            BucketId = bucketId;
        }
    }
}
