using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Kay_FileNameChanger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (!ArgumentValidator.IsValidArgs(args))
            {
                return;
            }

            WelcomeDisplay.DisplayWelcome(args);

            var response = Console.ReadLine();

            if (response.Contains('Y') && response != string.Empty) 
            {
                try
                {
                    
                    string startingDirectory = args[0];
                    string finishedDirectory = args[1];
                    string fileSearchExpression = args[2];

                    var directoryResult = Directory.GetFiles(startingDirectory, $"*{fileSearchExpression}");

                    foreach (var file in directoryResult)
                    {

                        var uncleanName = Path.GetFileNameWithoutExtension(file);

                        Regex nonAlphaWhitelist = new Regex("[^a-zA-Z0-9]");
                        Regex removeExtraHypens = new Regex("-{2,}");
                        var cleanName = nonAlphaWhitelist.Replace(uncleanName, "-").TrimStart('-').TrimEnd('-')
                            .ToLower();

                        cleanName = removeExtraHypens.Replace(cleanName, "-");

                        Console.WriteLine("Old: " + uncleanName);
                        Console.WriteLine("New: " + cleanName);

                        if (File.Exists(finishedDirectory + '\\' + cleanName + ".txt"))
                        {
                            continue;
                        }

                        File.Copy(file, finishedDirectory +'\\'+ cleanName + ".txt");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred, Try again or consult Wardy with error message");
                    Console.WriteLine(ex.ToString());
                }
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}