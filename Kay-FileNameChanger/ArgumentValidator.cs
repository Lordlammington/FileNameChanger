
namespace Kay_FileNameChanger
{
    public static class ArgumentValidator
    {

        public static bool IsValidArgs(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine(
                    "Please Input 3 arguments before running this program");
                Console.WriteLine(
                    "Argument 1: the directory of where your files are located  e.g C:/Files/Input");
                Console.WriteLine(
                    "Argument 2: Where you'd like your files to end up after this process e.g C:/Files/Output");
                Console.WriteLine(
                    "Argument 3: the extension (format) of the file you want to look for e.g. .png or .pdf");
                return false;
            }

            

            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("Argument 1 is not a valid Filepath");
                return false;
            }

            if (!Directory.Exists(args[1]))
            {
                Console.WriteLine("Argument 2 is not a valid Filepath");
                return false;
            }

            return true;
        }
    }
}
