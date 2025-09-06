using CommandLine;
using FileHasher.CLI.Commands;

return Parser.Default.ParseArguments<CheckCommandOptions, HashCommandOptions>(args)
    .MapResult(
        (CheckCommandOptions opts) => CheckCommand.Run(opts),
        (HashCommandOptions opts) => HashCommand.Run(opts),
        errs => 1);