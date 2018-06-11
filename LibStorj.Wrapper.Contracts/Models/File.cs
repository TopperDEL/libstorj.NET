namespace LibStorj.Wrapper.Contracts.Models
{
    public class File
    {
        public string Id { get; private set; }
        public string BucketId { get; private set; }
        public string Name { get; private set; }
        public string Created { get; private set; }
        public bool IsDecrypted { get; private set; }
        public long Size { get; private set; }
        public string MimeType { get; private set; }
        public string Erasure { get; private set; }
        public string Index { get; private set; }
        public string Hmac { get; private set; }
        public string FileName { get; set; }
        /// <summary>
        /// The Storj Bridge has a flat structure of bucket and files. There is no real
        /// file tree structure with subdirectories.However, a pseudo tree structure can
        /// be maintained by clients using file paths as the file name, e.g.
        /// "mydir/mysubdir/myfile". It is assumed that a file is a directory if its name
        /// ends with a slash character, e.g. "mydir/mysubdir/".
        /// </summary>
        public bool IsDirectory { get; set; }

        public File(string id, string bucketId, string name, string created, bool isDecrypted, long size, string mimeType, string erasure, string index, string hmac,string fileName, bool isDirectory)
        {
            Id = id;
            BucketId = bucketId;
            Name = name;
            Created = created;
            IsDecrypted = isDecrypted;
            Size = size;
            MimeType = mimeType;
            Erasure = erasure;
            Index = index;
            Hmac = hmac;
            FileName = fileName;
            IsDirectory = isDirectory;
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
