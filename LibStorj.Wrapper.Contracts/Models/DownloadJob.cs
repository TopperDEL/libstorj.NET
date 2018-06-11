namespace LibStorj.Wrapper.Contracts.Models
{
    public class DownloadJob : JobBase
    {
        public ProgressStatusDownload CurrentProgress { get; set; }
        public string FileId { get; set; }

        public DownloadJob(string fileId)
        {
            FileId = fileId;
            CurrentProgress = new ProgressStatusDownload(fileId, 0, 0, 0);
        }
    }
}
