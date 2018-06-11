namespace LibStorj.Wrapper.Contracts.Exceptions
{
    public class RegisterFailedException : GenericException
    {
        public RegisterFailedException(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
    }
}
