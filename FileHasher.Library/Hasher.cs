using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FileHasher.Library
{
    public static class Hasher
    {
        public static Hash File(string path)
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan);

            return Stream(stream);
        }

        public static Hash String(string data)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            return Stream(stream);
        }

        public static Hash Stream(Stream stream)
        {
            stream.Position = 0;
            var md5Hash = Md5Hash(stream);
            
            stream.Position = 0;
            var sha1Hash = Sha1Hash(stream);

            return new Hash(md5Hash, sha1Hash);
        }

        private static string Md5Hash(Stream stream)
        {
            var hashMd5 = MD5.Create().ComputeHash(stream);

            return BitConverter.ToString(hashMd5).ToLowerInvariant().Replace("-", string.Empty);
        }

        private static string Sha1Hash(Stream stream)
        {
            var hashSha1 = SHA1.Create().ComputeHash(stream);

            return BitConverter.ToString(hashSha1).ToLowerInvariant().Replace("-", string.Empty);
        }
    }
}

