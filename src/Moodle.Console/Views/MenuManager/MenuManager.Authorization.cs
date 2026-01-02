using Moodle.Console.Helpers;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        private async Task<UserRole> HandleLoginUserAsync()
        {
            while (true)
            {
                var input = Reader.ReadInput("User.Role (Student/Professor/Admin): ");

                if (Enum.TryParse<UserRole>(input, true, out var role))
                    return role;

                Writer.WriteMessage("Invalid role. Please enter Student, Professor, or Admin.");
            }
        }


        public async Task HandleRegisterUserAsync()
        {

        }
    }
}
