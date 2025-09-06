using CommandLine;
using FileHasher.CLI.Commands;

return Parser.Default.ParseArguments<HashCommandOptions>(args)
    .MapResult(HashCommand.Run, errs => 1);