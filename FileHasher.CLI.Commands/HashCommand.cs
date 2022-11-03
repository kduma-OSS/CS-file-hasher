using System.Diagnostics;
using System.Text;
using ColorConsoleLibrary;
using FileHasher.Library;

namespace FileHasher.CLI.Commands;

public static class HashCommand
{
    public static int Run(HashCommandOptions options)
    {
        Debug.Assert(options.Files != null, "options.Files != null");

        var good = 0; 
        var bad = 0; 
        
        foreach (var file in options.Files)
        {
            try {
                var hash = Hasher.File(file);

                switch (options.Type)
                {
                    case HashCommandOptions.AvailableHashTypes.Both:
                        using (var stream = new FileStream($"{file}.ph", FileMode.Create, FileAccess.Write, FileShare.Read,4096, FileOptions.SequentialScan))
                        {
                            stream.Write(hash.Pack());
                        }
                        break;
                    
                    case HashCommandOptions.AvailableHashTypes.Md5:
                        using (var stream = new FileStream($"{file}.md5", FileMode.Create, FileAccess.Write, FileShare.Read,4096, FileOptions.SequentialScan))
                        {
                            stream.Write(Encoding.UTF8.GetBytes(hash.Md5));
                        }
                        break;
                    
                    case HashCommandOptions.AvailableHashTypes.Sha1:
                        using (var stream = new FileStream($"{file}.sha1", FileMode.Create, FileAccess.Write, FileShare.Read,4096, FileOptions.SequentialScan))
                        {
                            stream.Write(Encoding.UTF8.GetBytes(hash.Sha1));
                        }
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                good++;
            } catch (FileNotFoundException)
            {
                ColorConsole.WriteLine($"File {file} was not found!", ConsoleColor.Red);
                
                bad++;
            }
        }

        if (bad == 0)
            return 0;
        
        return good == 0 ? 1 : 2;
    }
}