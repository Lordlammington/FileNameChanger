
namespace Kay_FileNameChanger
{
    internal static class WelcomeDisplay
    {
        public static void DisplayWelcome(string[] args)
        {
            Console.WriteLine("░█▀▀░▀█▀░█░░░█▀▀░░░█▀█░█▀█░█▄█░█▀▀░░░█░█░█▀█░█▀▄░█▀█░▀█▀░█▀▀░█▀▄");
            Console.WriteLine("░█▀▀░░█░░█░░░█▀▀░░░█░█░█▀█░█░█░█▀▀░░░█░█░█▀▀░█░█░█▀█░░█░░█▀▀░█▀▄");
            Console.WriteLine("░▀░░░▀▀▀░▀▀▀░▀▀▀░░░▀░▀░▀░▀░▀░▀░▀▀▀░░░▀▀▀░▀░░░▀▀░░▀░▀░░▀░░▀▀▀░▀░▀");
            Console.WriteLine("By Wardy :)");

            Console.WriteLine($"You've selected: {args[0]} As your starting directory? Y?");
            Console.WriteLine($"You've selected: {args[1]} As your destination directory? Y?");
            Console.WriteLine($"You've selected: {args[2]} As the file to search for Y?");
            Console.WriteLine("Are these inputs Correct? Y / N");
        }

    }
}
