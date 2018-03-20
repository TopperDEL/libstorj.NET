using LibStorj.Wrapper.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper
{
    public class StorjUtils : IStorjUtils
    {
        public bool CheckMnemonic(string mnemonic)
        {
            return io.storj.libstorj.Storj.checkMnemonic(mnemonic);
        }

        public string GenerateMnemonic(int strength)
        {
            return io.storj.libstorj.Storj.generateMnemonic(strength);
        }

        public string GetErrorMessage(int errorCode)
        {
            return io.storj.libstorj.Storj.getErrorMessage(errorCode);
        }

        public long GetTimestamp()
        {
            return io.storj.libstorj.Storj.getTimestamp();
        }
    }
}
