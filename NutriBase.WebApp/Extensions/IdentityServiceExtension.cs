using System;

namespace NutriBase.WebApp.Extensions;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config) 
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    }
}
