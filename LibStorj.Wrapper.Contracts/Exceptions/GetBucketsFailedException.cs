namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GetBucketsFailedException : GenericException
    {
        public GetBucketsFailedException(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
    }
}
