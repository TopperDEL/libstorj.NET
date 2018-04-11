using System;
using System.Collections.Generic;
using System.Text;

namespace LibStorj.Wrapper.Contracts.Models
{
    public abstract class Entry
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string SimpleName { get; private set; }
        public string Created { get; private set; }
        public bool IsDecrypted { get; private set; }

        public Entry(string id, string name, string simpleName, string created, bool isDecrypted)
        {
            Id = id;
            Name = name;
            SimpleName = simpleName;
            Created = created;
            IsDecrypted = isDecrypted;
        }

        public override bool Equals(object obj)
        {
            if (obj is File)
            {
                File file = (File)obj;
                return file.Id == this.Id;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
