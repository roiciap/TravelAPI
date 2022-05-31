using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI.Authorization
{
    public class UserOperationRequirementHandler:AuthorizationHandler<UserIdOperationRequirement,Rezerwacja>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,UserIdOperationRequirement requirement, Rezerwacja rezerwacja)
        {
            if (requirement.UserOperation != UserOperation.CreateRezerwacja)
            {
                context.Succeed(requirement);
            }
            
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (rezerwacja.KlientId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
            
        }
    }
}
