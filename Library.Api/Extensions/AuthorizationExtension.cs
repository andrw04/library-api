using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Library.Api.Extensions;

public static class AuthorizationExtension
{
    public static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
    {

        services.AddAuthorization(options =>
        {
            var policyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);

            options.DefaultPolicy = policyBuilder.RequireAuthenticatedUser().Build();
        });

        return services;
    }
}
