using LibStorj.Wrapper.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper
{
    /// <summary>
    /// Provides Info about the version of the underlying dependencies
    /// </summary>
    public class VersionInfo : IVersionInfo
    {
        /// <summary>
        /// Provides the curl-version
        /// </summary>
        /// <returns>The curl-version in use</returns>
        public string GetCurlVersion()
        {
            return io.storj.libstorj.NativeLibraries.getCurlVersion();
        }

        /// <summary>
        /// Provides the json-C-version
        /// </summary>
        /// <returns>The json-C-version</returns>
        public string GetJsonCVersion()
        {
            return io.storj.libstorj.NativeLibraries.getJsonCVersion();
        }

        /// <summary>
        /// Provides the libuv-version
        /// </summary>
        /// <returns>The livuv-version</returns>
        public string GetLibuvCVersion()
        {
            return io.storj.libstorj.NativeLibraries.getLibuvVersion();
        }

        /// <summary>
        /// PRovides the nettle-version
        /// </summary>
        /// <returns>The nettle-version</returns>
        public string GetNettleVersion()
        {
            return io.storj.libstorj.NativeLibraries.getNettleVersion();
        }
    }
}
