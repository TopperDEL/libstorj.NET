using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
