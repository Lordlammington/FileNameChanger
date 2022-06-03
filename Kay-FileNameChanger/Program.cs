using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Kay_FileNameChanger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //foo
            //foo

            if (!ArgumentValidator.IsValidArgs(args))
            {
                return;
            }

            WelcomeDisplay.DisplayWelcome(args);

            var response = Console.ReadLine();

            if (!response!.Contains('Y') || response == string.Empty) return;

            try
            {
                    
                var startingDirectory = args[0];
                var finishedDirectory = args[1];
                var fileSearchExpression = args[2];

                var directoryResult = Directory.GetFiles(startingDirectory, $"*{fileSearchExpression}");

                foreach (var file in directoryResult)
                {

                    var uncleanName = Path.GetFileNameWithoutExtension(file);

                    var nonAlphaWhitelist = new Regex("[^a-zA-Z0-9]");
                    var removeExtraHypens = new Regex("-{2,}");
                    var cleanName = nonAlphaWhitelist.Replace(uncleanName, "-").TrimStart('-').TrimEnd('-')
                        .ToLower();

                    cleanName = removeExtraHypens.Replace(cleanName, "-");

                    Console.WriteLine("Old: " + uncleanName);
                    Console.WriteLine("New: " + cleanName);

                    if (File.Exists(finishedDirectory + '\\' + cleanName + args[2]))
                    {
                        continue;
                    }

                    File.Copy(file, finishedDirectory +'\\'+ cleanName + args[2]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred, Try again or consult Wardy with error message");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}