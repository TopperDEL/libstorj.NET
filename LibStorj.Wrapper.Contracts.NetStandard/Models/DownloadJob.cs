using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Models
{
    public class DownloadJob
    {
        public long Id { get; set; }
        public bool IsFinished { get; set; }
        public bool IsOnError { get; set; }
        public ProgressStatusDownload CurrentProgress { get; set; }

        public DownloadJob(string fileId)
        {
            CurrentProgress = new ProgressStatusDownload(fileId, 0, 0, 0);
        }
    }
}
