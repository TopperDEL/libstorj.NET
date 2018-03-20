using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
