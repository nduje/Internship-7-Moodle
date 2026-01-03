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

        public static bool ReadCaptcha()
        {
            var random = new Random();
            const string letters = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            const string digits = "0123456789";

            while (true)
            {
                var captchaChars = new List<char>
                    {
                        letters[random.Next(letters.Length)],
                        digits[random.Next(digits.Length)]
                    };

                int length = random.Next(4, 6);
                const string allChars = letters + digits;

                for (int i = 0; i < length - 2; i++)
                {
                    captchaChars.Add(allChars[random.Next(allChars.Length)]);
                }

                captchaChars = captchaChars.OrderBy(_ => random.Next()).ToList();
                var captcha = new string(captchaChars.ToArray());

                Writer.WriteMessage($"\nCAPTCHA: {captcha}");
                var input = ReadInput("Enter CAPTCHA (or type /exit to go back): ");

                if (input == "/exit")
                    return false;

                if (input == captcha)
                    return true;

                Writer.WriteMessage("Incorrect captcha, try again.");
            }
        }

    }
}
