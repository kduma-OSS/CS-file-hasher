using CommandLine;
using FileHasher.CLI.Commands;

namespace FileHasher.CLI
{
    static class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<CheckCommandOptions, HashCommandOptions>(args)
                .MapResult(
                    (CheckCommandOptions opts) => CheckCommand.Run(opts),
                    (HashCommandOptions opts) => HashCommand.Run(opts),
                    errs => 1);
        }
    }
}