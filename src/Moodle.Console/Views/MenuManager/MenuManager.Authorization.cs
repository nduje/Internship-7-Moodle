using Moodle.Console.Helpers;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        private async Task HandleLoginUserAsync()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("=== Login ===");

                var email = Reader.ReadInput("\nEnter email (type /exit to go back):");

                if (email == "/exit")
                {
                    return;
                }

                var password = Reader.ReadInput("\nEnter password (type /exit to go back):");

                if (password == "/exit")
                {
                    return;
                }

                _currentUser = await _userActions.LoginUserAsync(email, password);

                if (_currentUser == null)
                {
                    Writer.WriteMessage("\nInvalid credentials.");
                    Writer.WaitForKey();
                    continue;
                }

                else
                {
                    Writer.WriteMessage($"\nWelcolme, {_currentUser.FirstName}.");
                    Writer.WaitForKey();
                    break;
                }
            }
        }

        public async Task HandleRegisterUserAsync()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== Register New User ===");

            string email;

            do
            {
                email = Reader.ReadInput("\nEnter email (type /exit to go back):");
                
                if (email == "/exit")
                {
                    return;
                }

                if (!EmailRegex.IsMatch(email))
                {
                    System.Console.WriteLine("\nInvalid email format. Try again.");
                }
            } while (!EmailRegex.IsMatch(email));

            string password;

            password = Reader.ReadInput("\nEnter password (type /exit to go back):").Trim();

            if (password == "/exit")
            {
                return;
            }

            string confirm_password;

            do
            {
                confirm_password = Reader.ReadInput("\nConfirm password (type /exit to go back):");

                if (confirm_password == "/exit")
                {
                    return;
                }

                if (confirm_password != password)
                {
                    System.Console.WriteLine("\nPasswords do not match. Try again.");
                }
            } while (confirm_password != password);

            Writer.WriteMessage("\nComplete the CAPTCHA to continue.");
            if (!Reader.ReadCaptcha())
            {
                return;
            }

            var first_name = Reader.ReadInput("\nEnter first name (type /exit to go back):");

            if (first_name == "/exit")
            {
                return;
            }

            var last_name = Reader.ReadInput("\nEnter last name (type /exit to go back):");

            if (last_name == "/exit")
            {
                return;
            }

            var user_id = await _userActions.RegisterUserAsync(
                first_name,
                last_name,
                null,
                email,
                password);

            if (user_id == Guid.Empty)
            {
                Writer.WriteMessage("\nFailed to register user.");
                Writer.WaitForKey();
            }

            else
            {
                Writer.WriteMessage($"\nUser {first_name + " " + last_name} has been successfully registered.");
                Writer.WaitForKey();
            }
        }
    }
}
