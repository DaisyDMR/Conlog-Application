using Abp.Authorization;
using Simple.Todo.Authorization.Roles;
using Simple.Todo.Authorization.Users;

namespace Simple.Todo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
