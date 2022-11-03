using CommandLine;
using FileHasher.CLI.Commands;

namespace FileHasher.CLI.Check
{
    static class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<CheckCommandOptions>(args)
                .MapResult(CheckCommand.Run, errs => 1);
        }
    }
}