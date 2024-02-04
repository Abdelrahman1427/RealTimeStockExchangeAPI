using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



namespace RealTimeStockExchangeAPI.Middleware
{ 
public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration config;

    public JwtMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        this.config = config;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            attachUserToContext(context, token);

        await _next(context);
    }

    private void attachUserToContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:key"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = "http://localhost:5259",
                ValidAudience = "http://localhost:5259",

                ClockSkew = TimeSpan.FromMinutes(1),
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
;
        }
        catch
        {

        }
    }
} 
}