namespace LibStorj.Wrapper.Contracts.Interfaces
{
    public interface IStorjUtils
    {
        long GetTimestamp();
        string GenerateMnemonic(int strength);
        bool CheckMnemonic(string mnemonic);
        string GetErrorMessage(int errorCode);
    }
}
