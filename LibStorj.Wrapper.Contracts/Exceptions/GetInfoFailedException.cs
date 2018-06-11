namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class GetInfoFailedException : GenericException
    {
        public GetInfoFailedException(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
    }
}
