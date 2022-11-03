using System;
using System.IO;
using MessagePack;

namespace FileHasher.Library
{
    [MessagePackObject]
    public class Hash
    {
        [Key("md5")]
        public string Md5 { get; }
        
        [Key("sha1")]
        public string Sha1 { get; }

        public Hash(string md5, string sha1)
        {
            Md5 = md5;
            Sha1 = sha1;
        }

        public byte[] Pack()
        {
            return MessagePackSerializer.Serialize(this);
        }

        public static Hash Unpack(byte[] data)
        {
            return MessagePackSerializer.Deserialize<Hash>(data);
        }
        
        public static Hash Unpack(Stream stream)
        {
            return MessagePackSerializer.Deserialize<Hash>(stream);
        }
        
        
        protected bool Equals(Hash other)
        {
            return Md5 == other.Md5 && Sha1 == other.Sha1;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Hash)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Md5, Sha1);
        }

        public static bool operator ==(Hash left, Hash right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Hash left, Hash right)
        {
            return !Equals(left, right);
        }
    }
}