using Microsoft.AspNetCore.Authorization;

namespace KolomiietsM_HomeWork11.OwnRequirement
{
    public class OwnEditRequirement : IAuthorizationRequirement
    {
        protected internal string AccessRole { get; set; }

        public OwnEditRequirement(string AccessRole)
        {
            this.AccessRole = AccessRole;
        }
    }
}
