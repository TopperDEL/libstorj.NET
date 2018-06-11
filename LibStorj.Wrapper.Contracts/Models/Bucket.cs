namespace LibStorj.Wrapper.Contracts.Models
{
    public class Bucket
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Created { get; internal set; }
        public bool IsDecrypted { get; internal set; }

        public Bucket(string id, string name, string created, bool isDecrypted)
        {
            Id = id;
            Name = name;
            Created = created;
            IsDecrypted = isDecrypted;
        }

        public override bool Equals(object obj)
        {
            if (obj is Bucket)
            {
                Bucket b = (Bucket)obj;
                return b.Id == this.Id;
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
