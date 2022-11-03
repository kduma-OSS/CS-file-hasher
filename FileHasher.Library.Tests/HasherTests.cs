using System.Reflection;

namespace FileHasher.Library.Tests;

public class HasherTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestStreamHashing()
    {
        var hash = Hasher.Stream(new MemoryStream(10));
        
        Assert.Multiple(() =>
        {
            Assert.That(hash.Md5, Is.EqualTo("d41d8cd98f00b204e9800998ecf8427e"), "MD5 hash is invalid");
            Assert.That(hash.Sha1, Is.EqualTo("da39a3ee5e6b4b0d3255bfef95601890afd80709"), "SHA1 hash is invalid");
        });
    }

    [Test]
    public void TestStringHashing()
    {
        var hash = Hasher.String("Test String");
        
        Assert.Multiple(() =>
        {
            Assert.That(hash.Md5, Is.EqualTo("bd08ba3c982eaad768602536fb8e1184"), "MD5 hash is invalid");
            Assert.That(hash.Sha1, Is.EqualTo("a5103f9c0b7d5ff69ddc38607c74e53d4ac120f2"), "SHA1 hash is invalid");
        });
    }

    [Test]
    public void TestFileHashing()
    {
        var path = GetFilePath("test.txt");

        var hash = Hasher.File(path);
        
        Assert.Multiple(() =>
        {
            Assert.That(hash.Md5, Is.EqualTo("dfee14c3ca5a537621c67ffba86333b7"), "MD5 hash is invalid");
            Assert.That(hash.Sha1, Is.EqualTo("8378ce510c9bb1712053fea04659c84d4554c463"), "SHA1 hash is invalid");
        });
    }

    private static string GetFilePath(string file)
    {
        return $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/{file}";
    }
}
