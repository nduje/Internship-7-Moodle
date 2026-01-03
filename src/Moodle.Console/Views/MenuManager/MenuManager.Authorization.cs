using Moodle.Console.Helpers;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        private async Task<User?> HandleLoginUserAsync()
        {
            while (true)
            {
                var email = "luka.lukic@moodle.hr";
                var password = "Student@123!";

                return await _userActions.LoginUserAsync(email, password);
            }
        }

        public async Task HandleRegisterUserAsync()
        {

        }
    }
}
