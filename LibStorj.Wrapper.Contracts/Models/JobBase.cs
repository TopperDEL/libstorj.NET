using System;
using System.Collections.Generic;
using System.Text;

namespace LibStorj.Wrapper.Contracts.Models
{
    public delegate void ProgressChanged(JobBase job);
    public delegate void JobFinished(JobBase job);
    public delegate void JobFailed(JobBase job);

    public abstract class JobBase
    {
        public long Id { get; set; }
        public bool IsFinished { get; set; }
        public bool IsOnError { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public event ProgressChanged ProgressChanged;
        public event JobFinished JobFinished;
        public event JobFailed JobFailed;

        public void RaiseProgressChanged()
        {
            if (ProgressChanged != null)
                ProgressChanged(this);
        }

        public void RaiseJobFinished()
        {
            if (JobFinished != null)
                JobFinished(this);
        }

        public void RaiseJobFailed()
        {
            if (JobFailed != null)
                JobFailed(this);
        }
    }
}
