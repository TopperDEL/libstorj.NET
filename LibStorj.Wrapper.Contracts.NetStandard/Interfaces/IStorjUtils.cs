using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Interfaces
{
    public interface IStorjUtils
    {
        long GetTimestamp();
        string GenerateMnemonic(int strength);
        bool CheckMnemonic(string mnemonic);
        string GetErrorMessage(int errorCode);
    }
}
