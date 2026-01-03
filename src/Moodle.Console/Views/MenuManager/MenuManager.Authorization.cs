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
                var email = "sven@moodle.hr";
                var password = "Professor@123!";

                return await _userActions.LoginUserAsync(email, password);
            }
        }

        public async Task HandleRegisterUserAsync()
        {

        }
    }
}
