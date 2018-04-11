using System;
using System.Collections.Generic;
using System.Text;

namespace LibStorj.Wrapper.Contracts.Models
{
    public class Directory : Entry
    {
        public Directory(Entry entry) : base(entry.Id, entry.Name, entry.SimpleName, entry.Created, entry.IsDecrypted)
        {
        }

        public Directory(string id, string name, string simpleName, string created, bool isDecrypted) : base(id, name, simpleName, created, isDecrypted)
        {

        }
    }
}
