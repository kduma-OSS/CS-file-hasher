using CommandLine;
using FileHasher.CLI.Commands;

namespace FileHasher.CLI.Hash
{
    static class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<HashCommandOptions>(args)
                .MapResult(HashCommand.Run, errs => 1);
        }
    }
}