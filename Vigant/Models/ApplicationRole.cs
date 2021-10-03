using Microsoft.AspNetCore.Identity;

namespace Vigant.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name) : base(name)
        {

        }
    }
}
