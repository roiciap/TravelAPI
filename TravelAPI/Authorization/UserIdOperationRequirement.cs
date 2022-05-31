using Microsoft.AspNetCore.Authorization;
using TravelAPI.Models;

namespace TravelAPI.Authorization
{
    public enum UserOperation
    {
        CreateRezerwacja,
        ReadRezerwacja,
        UpdateRezerwacja,
        DeleteRezerwacja
    }
    public class UserIdOperationRequirement:IAuthorizationRequirement
    {
        public UserIdOperationRequirement(UserOperation uOperation)
        {
            UserOperation = uOperation;
                
        }
        public UserOperation UserOperation { get; }


    }
}
