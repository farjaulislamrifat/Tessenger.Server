using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Configuration;

namespace Tessenger.Server.Authentications
{
    public class Service_AuthFillter_Without_Connect : IAuthorizationFilter
    {
        IConfiguration configuration;
        public Service_AuthFillter_Without_Connect(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var header_Key = context.HttpContext.Request.Headers["x-api-key-temp"].FirstOrDefault();
            var temp_api_key = configuration.GetSection("temp_x_api_key").Value;

            if(header_Key != temp_api_key)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                // Do nothing, allow the request to proceed
            }
        }
    }
}
