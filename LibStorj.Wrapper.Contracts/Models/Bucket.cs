using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Models
{
    public class Bucket : Entry
    {
        public Bucket(string id, string name, string simpleName, string created, bool isDecrypted) : base(id, name, simpleName, created, isDecrypted)
        {
        }
    }
}
