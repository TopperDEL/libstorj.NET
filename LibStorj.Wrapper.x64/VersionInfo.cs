using LibStorj.Wrapper.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper
{
    public class VersionInfo : IVersionInfo
    {
        public string GetCurlVersion()
        {
            return io.storj.libstorj.NativeLibraries.getCurlVersion();
        }

        public string GetJsonCVersion()
        {
            return io.storj.libstorj.NativeLibraries.getJsonCVersion();
        }

        public string GetLibuvCVersion()
        {
            return io.storj.libstorj.NativeLibraries.getLibuvVersion();
        }

        public string GetNettleVersion()
        {
            return io.storj.libstorj.NativeLibraries.getNettleVersion();
        }
    }
}
