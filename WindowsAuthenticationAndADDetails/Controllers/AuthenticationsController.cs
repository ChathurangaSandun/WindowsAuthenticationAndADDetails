using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WindowsAuthenticationAndADDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        public AuthenticationsController()
        {

        }

        [Route("loggeduser")]
        [HttpGet]
        public ActionResult<string> GetLoggedUserName()
        {
            return User.Identity.Name;
        }

        [Route("userdetails")]
        [HttpGet]
        public ActionResult<UserPrincipal> GetLoggedUserAllDetails()
        {
            var username = User.Identity.Name;
            //depending on your environment, you may need to specify a container along with the domain
            //ex: new PrincipalContext(ContextType.Domain, "yourdomain", "OU=abc,DC=xyz")
            using (var context = new PrincipalContext(ContextType.Domain, "SL"))
            {
                var user = UserPrincipal.FindByIdentity(context, username);
                    return user;
                
            }
        }

    }
}