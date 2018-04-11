using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Models
{
    public class File:Entry
    {
        public string BucketId { get; private set; }
        public long Size { get; private set; }
        public string MimeType { get; private set; }
        public string Erasure { get; private set; }
        public string Index { get; private set; }
        public string Hmac { get; private set; }
        /// <summary>
        /// The Storj Bridge has a flat structure of bucket and files. There is no real
        /// file tree structure with subdirectories.However, a pseudo tree structure can
        /// be maintained by clients using file paths as the file name, e.g.
        /// "mydir/mysubdir/myfile". It is assumed that a file is a directory if its name
        /// ends with a slash character, e.g. "mydir/mysubdir/".
        /// </summary>
        public bool IsDirectory { get; set; }

        public File(string id, string bucketId, string name, string simpleName, string created, bool isDecrypted, long size, string mimeType, string erasure, string index, string hmac, bool isDirectory) :
            base(id, name, simpleName, created, isDecrypted)
        {
            BucketId = bucketId;
            Size = size;
            MimeType = mimeType;
            Erasure = erasure;
            Index = index;
            Hmac = hmac;
            IsDirectory = isDirectory;
        }
    }
}
