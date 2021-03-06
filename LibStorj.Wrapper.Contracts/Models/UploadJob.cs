﻿namespace LibStorj.Wrapper.Contracts.Models
{
    public class UploadJob : JobBase
    {
        public ProgressStatusUpload CurrentProgress { get; set; }
        public string FileName { get; set; }

        public UploadJob(string fileName)
        {
            FileName = fileName;
            CurrentProgress = new ProgressStatusUpload(fileName, 0, 0, 0);
        }
    }
}
