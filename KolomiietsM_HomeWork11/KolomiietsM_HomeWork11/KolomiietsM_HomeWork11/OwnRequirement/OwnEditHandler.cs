using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork11.OwnRequirement
{
    public class OwnEditHandler : AuthorizationHandler<OwnEditRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnEditRequirement requirement)
        {
            if (context.User.HasClaim(i => i.Type == "readEditText"))
            {
                var readEdit = context.User.FindFirstValue("readEditText");

                if (readEdit == "readEditText")
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
