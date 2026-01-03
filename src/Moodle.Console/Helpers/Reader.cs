namespace Moodle.Console.Helpers
{
    public static class Reader
    {
        public static string ReadLine()
        {
            return System.Console.ReadLine() ?? "";
        }

        public static string ReadInput(string prompt)
        {
            System.Console.WriteLine(prompt);

            return System.Console.ReadLine() ?? "";
        }

        public static int? ReadInt(string prompt)
        {
            System.Console.Write(prompt);
            
            var input = System.Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }

            return null;
        }

        public static string ReadMenuChoice(string prompt = "\nSelect an option: ")
        {
            System.Console.Write(prompt);

            return System.Console.ReadLine() ?? "";
        }

    }
}
