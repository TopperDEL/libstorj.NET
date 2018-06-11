namespace LibStorj.Wrapper.Contracts.Models
{
    public class ProgressStatusDownload
    {
        public string FileId { get; set; }
        public double Progress { get; set; }
        public long DoneBytes { get; set; }
        public long TotalBytes { get; set; }

        public ProgressStatusDownload(string fileId, double progress, long doneBytes, long totalBytes)
        {
            FileId = fileId;
            Progress = progress;
            DoneBytes = doneBytes;
            TotalBytes = totalBytes;
        }
    }
}
