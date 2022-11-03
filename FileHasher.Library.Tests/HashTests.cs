using System.Reflection;

namespace FileHasher.Library.Tests;

public class HashTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestInMemory()
    {
        var hash = new Hash("md5", "sha1");

        var bytes = hash.Pack();

        var unpacked = Hash.Unpack(bytes);
        
        Assert.That(unpacked, Is.EqualTo(hash));
    }

    [Test]
    public void TestUnpackingFromFile()
    {
        using var stream = new FileStream(GetFilePath("test.txt.ph"), FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan);
        
        var unpacked = Hash.Unpack(stream);
        Assert.Multiple(() =>
        {
            const string md5 = "dfee14c3ca5a537621c67ffba86333b7";
            const string sha1 = "8378ce510c9bb1712053fea04659c84d4554c463";
            
            Assert.That(unpacked.Md5, Is.EqualTo(md5));
            Assert.That(unpacked.Sha1, Is.EqualTo(sha1));
            
            Assert.That(unpacked, Is.EqualTo(new Hash(md5, sha1)));
        });
    }

    private static string GetFilePath(string file)
    {
        return $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/{file}";
    }
}