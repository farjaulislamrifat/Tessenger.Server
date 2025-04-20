using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tessenger.Server.Hubs;
using Tessenger.Server.Users_Identity;

namespace Tessenger.Server.Authentications
{
    public class Service_AuthFillter : IAuthorizationFilter
    {

        IConfiguration configuration;
        public Service_AuthFillter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context )
        {
            var header_Key = context.HttpContext.Request.Headers["x-api-key"].FirstOrDefault();
            var temp_header_Key = context.HttpContext.Request.Headers["x-api-key-temp"].FirstOrDefault();

            if(temp_header_Key == null)
            {
                var user = User_Usernames_By_Connection.Users;
                var t = user.Values.FirstOrDefault(c => c.Contains(header_Key));
                if (t == null)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            


        }
    }

}

