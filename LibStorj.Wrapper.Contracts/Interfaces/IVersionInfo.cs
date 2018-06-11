namespace LibStorj.Wrapper.Contracts.Interfaces
{
    public interface IVersionInfo
    {
        string GetJsonCVersion();
        string GetCurlVersion();
        string GetLibuvCVersion();
        string GetNettleVersion();
    }
}
