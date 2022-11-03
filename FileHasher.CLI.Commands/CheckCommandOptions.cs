using CommandLine;

namespace FileHasher.CLI.Commands;

[Verb("check", HelpText = "Verify hashes for given file")]
public class CheckCommandOptions {
    [Value(0, MetaName = "files", HelpText = "Hash files to check", Required = true)]
    public IEnumerable<string>? Files { get; set; }
}