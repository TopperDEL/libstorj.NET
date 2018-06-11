namespace LibStorj.Wrapper.Contracts.Models
{
    public class ProgressStatusUpload
    {
        public string FilePath { get; set; }
        public double Progress { get; set; }
        public long DoneBytes { get; set; }
        public long TotalBytes { get; set; }

        public ProgressStatusUpload(string filePath, double progress, long doneBytes, long totalBytes)
        {
            FilePath = filePath;
            Progress = progress;
            DoneBytes = doneBytes;
            TotalBytes = totalBytes;
        }
    }
}
