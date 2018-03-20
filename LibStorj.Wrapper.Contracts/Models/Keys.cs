using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Models
{
    public class Keys
    {
        public string User { get; private set; }
        public string Password { get; private set; }
        public string Mnemonic { get; private set; }

        public Keys(string user, string password, string mnemonic)
        {
            User = user;
            Password = password;
            Mnemonic = mnemonic;
        }
    }
}
