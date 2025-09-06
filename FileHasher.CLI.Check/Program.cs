using CommandLine;
using FileHasher.CLI.Commands;

return Parser.Default.ParseArguments<CheckCommandOptions>(args)
    .MapResult(CheckCommand.Run, errs => 1);