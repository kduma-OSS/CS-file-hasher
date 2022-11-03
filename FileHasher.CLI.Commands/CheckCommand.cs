using System.Diagnostics;
using System.Text;
using ColorConsoleLibrary;
using FileHasher.Library;

namespace FileHasher.CLI.Commands;

public static class CheckCommand
{
    public static int Run(CheckCommandOptions options)
    {
        Debug.Assert(options.Files != null, "options.Files != null");

        var good = 0; 
        var bad = 0; 
        
        foreach (var file in options.Files)
        {
            if (!File.Exists(file))
            {
                ColorConsole.WriteLine($"Hash file {file} doesn't exists!", ConsoleColor.Red);
                bad++;
                continue;
            }

            var fullPath = Path.GetFullPath(file);
            var extension = Path.GetExtension(fullPath);
            var baseFile = $"{Path.GetDirectoryName(fullPath)}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(fullPath)}";

            if (extension != ".ph" && extension != ".md5" && extension != ".sha1")
            {
                ColorConsole.WriteLine($"Hash format {extension} is not supported!", ConsoleColor.Red);
                bad++;
                continue;
            }
            
            if (!File.Exists(baseFile))
            {
                ColorConsole.WriteLine($"Base file {baseFile} doesn't exists!", ConsoleColor.Red);
                bad++;
                continue;
            }
            
            Hash? hash;
            var valid = false;
            switch (extension)
            {
                case ".ph":
                    var currentHashFile = Hash.Unpack(new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 1024));
                    valid = Checker.File(baseFile, currentHashFile);
                    break;
                case ".md5":
                    hash = Hasher.File(baseFile);
                    valid = hash.Md5 == File.ReadAllText(fullPath);
                    break;
                case ".sha1":
                    hash = Hasher.File(baseFile);
                    valid = hash.Sha1 == File.ReadAllText(fullPath);
                    break;
            }
            
            if (valid)
            {
                ColorConsole.WriteLine($"Hash file {fullPath} is valid for {baseFile}!", ConsoleColor.Green);
                good++;
            } else
            {
                ColorConsole.WriteLine($"Hash file {fullPath} is INVALID for {baseFile}!", ConsoleColor.Red);
                bad++;
            }
        }

        if (bad == 0)
            return 0;
        
        return good == 0 ? 1 : 2;
    }
}