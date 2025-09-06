using System.IO;

namespace FileHasher.Library
{
    public class Checker
    {
        public static bool File(string path, Hash hash)
        {
            var computedHash = Hasher.File(path);

            return computedHash == hash;
        }

        public static bool String(string data, Hash hash)
        {
            var computedHash = Hasher.String(data);

            return computedHash == hash;
        }

        public static bool Stream(Stream stream, Hash hash)
        {
            var computedHash = Hasher.Stream(stream);

            return computedHash == hash;
        }
    }
}

