using System.Reflection;

namespace FileHasher.Library.Tests;

public class CheckerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestStreamHashing()
    {
        var hash = Checker.Stream(new MemoryStream(10), new Hash("d41d8cd98f00b204e9800998ecf8427e", "da39a3ee5e6b4b0d3255bfef95601890afd80709"));
        
        Assert.That(hash, Is.EqualTo(true), "hash is invalid");
    }

    [Test]
    public void TestStringHashing()
    {
        var hash = Checker.String("Test String", new Hash("bd08ba3c982eaad768602536fb8e1184", "a5103f9c0b7d5ff69ddc38607c74e53d4ac120f2"));
        
        
        Assert.That(hash, Is.EqualTo(true), "hash is invalid");
    }

    [Test]
    public void TestFileHashing()
    {
        var path = GetFilePath("test.txt");

        var hash = Checker.File(path, new Hash("dfee14c3ca5a537621c67ffba86333b7", "8378ce510c9bb1712053fea04659c84d4554c463"));
        
        Assert.That(hash, Is.EqualTo(true), "hash is invalid");
    }

    private static string GetFilePath(string file)
    {
        return $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/{file}";
    }
}