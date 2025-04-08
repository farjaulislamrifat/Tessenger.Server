using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tessenger.Server.Hubs;

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
                var user = AuthHub.User;
                var t = user.Keys.FirstOrDefault(c => c.Contains(header_Key));
                if (header_Key==t)
                {

                }
            }
            


        }
    }

}

