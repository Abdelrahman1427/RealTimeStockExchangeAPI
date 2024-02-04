using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RealTimeStockExchangeAPI.Entitiy;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration config;

    public AuthController(IConfiguration config)
    {
        this.config = config;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel user)
    {
        if (user is null)
        {
            return BadRequest("Invalid client request");
        }
        var isuser = Authenticate(user);
        if (isuser != null)
        {
            var token = Generate(user);
            return Ok(token);
        }
        return Unauthorized();
    }

    private string Generate(LoginModel user)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signinCredentials
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }

    private LoginModel Authenticate(LoginModel userLogin)
    {
        var currentUser = ConstantModel.user.FirstOrDefault(a => a.UserName.ToLower() == userLogin.UserName.ToLower() &&
        a.Password == userLogin.Password);

        if (currentUser != null)
        {
            return currentUser;
        }

        return null;
    }
}




