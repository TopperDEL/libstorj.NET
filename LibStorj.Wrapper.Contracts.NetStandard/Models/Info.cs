using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Models
{
    public class Info
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Host { get; set; }

        public Info(string title, string description, string version, string host)
        {
            Title = title;
            Description = description;
            Version = version;
            Host = host;
        }
    }
}
