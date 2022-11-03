using CommandLine;

namespace FileHasher.CLI.Commands;

[Verb("hash", HelpText = "Generate hashes for given file")]
public class HashCommandOptions {
    [Value(0, MetaName = "files", HelpText = "Files to generate hashes for", Required = true)]
    public IEnumerable<string>? Files { get; set; }
            
    [Option('t', "type", Default = AvailableHashTypes.Both, HelpText = "Type of calculated hash (both,md5,sha1)")]
    public AvailableHashTypes? Type { get; set; }
            
    public enum AvailableHashTypes
    {
        Both, Md5, Sha1
    }
}