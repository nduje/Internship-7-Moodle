using Moodle.Application.Users.DTOs;
using Moodle.Application.Users.Handlers;
using Moodle.Domain.Enumerations.Users;


namespace Moodle.Console.Actions.Users
{
    public class UserActions
    {
        private readonly ChangeUserRoleRequestHandler _changeUserRoleRequestHandler;
        private readonly DeleteUserRequestHandler _deleteUserRequestHandler;
        private readonly GetUsersRequestHandler _getUsersRequestHandler;
        private readonly LoginUserRequestHandler _loginUserRequestHandler;
        private readonly RegisterUserRequestHandler _registerUserRequestHandler;
        private readonly UpdateUserEmailRequestHandler _updateUserEmailRequestHandler;

        public UserActions(
            ChangeUserRoleRequestHandler changeUserRoleRequestHandler,
            DeleteUserRequestHandler deleteUserRequestHandler,
            GetUsersRequestHandler getUsersRequestHandler,
            LoginUserRequestHandler loginUserRequestHandler,
            RegisterUserRequestHandler registerUserRequestHandler,
            UpdateUserEmailRequestHandler updateUserEmailRequestHandler)
        {
            _changeUserRoleRequestHandler = changeUserRoleRequestHandler;
            _deleteUserRequestHandler = deleteUserRequestHandler;
            _getUsersRequestHandler = getUsersRequestHandler;
            _loginUserRequestHandler = loginUserRequestHandler;
            _registerUserRequestHandler = registerUserRequestHandler;
            _updateUserEmailRequestHandler = updateUserEmailRequestHandler;
        }

        public async Task<ChangeUserRoleResponse?> ChangeUserRoleAsync(Guid id, UserRole role)
        {
            var result = await _changeUserRoleRequestHandler.UpdateRole(new ChangeUserRoleRequest(id, role));

            if (result.Value == null)
            {
                return null;
            }

            return new ChangeUserRoleResponse
            {
                Id = result.Value.Id,
                Role = result.Value.Role
            };
        }

        public async Task<DeleteUserResponse?> DeleteUserAsync(Guid id)
        {
            var result = await _deleteUserRequestHandler.DeleteUser(new DeleteUserRequest(id));

            if (result.Value == null)
            {
                return null;
            }

            return new DeleteUserResponse
            {
                Id = result.Value.Id
            };
        }


        public async Task<IReadOnlyList<GetUsersResponse>> GetUsersAsync(UserRole? role)
        {
            var result = await _getUsersRequestHandler.GetUsers(new GetUsersRequest(role));

            if (result.Value == null)
            {
                return Array.Empty<GetUsersResponse>();
            }

            return result.Value.Select(u => new GetUsersResponse
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }

        public async Task<Guid?> LoginUserAsync(string email, string password)
        {
            var result = await _loginUserRequestHandler.Login(new LoginUserRequest(email, password));

            if (result.Value == Guid.Empty)
            {
                return null;
            }

            return result.Value;
        }

        public async Task<Guid?> RegisterUserAsync(string first_name, string last_name, DateOnly? birth_date, string email, string password)
        {
            var result = await _registerUserRequestHandler.Register(new RegisterUserRequest(first_name, last_name, birth_date, email, password));

            if (result.Value == Guid.Empty)
            {
                return null;
            }

            return result.Value;
        }

        public async Task<UpdateUserEmailResponse?> UpdateEmailAsync(Guid id, string email)
        {
            var result = await _updateUserEmailRequestHandler.UpdateEmail(new UpdateUserEmailRequest(id, email));

            if (result.Value == null)
            {
                return null;
            }

            return new UpdateUserEmailResponse
            {
                Id = result.Value.Id,
                Email = result.Value.Email
            };
        }
    }
}