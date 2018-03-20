using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
