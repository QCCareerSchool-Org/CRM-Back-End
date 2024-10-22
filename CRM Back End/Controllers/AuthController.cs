namespace CRM.Controllers;

using CRM.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly string issuer;
    private readonly string audience;
    private readonly string secretKey;

    public AuthController(IOptions<JwtConfig> options)
    {
        this.issuer = options.Value.Issuer;
        this.audience = options.Value.Audience;
        this.secretKey = options.Value.SecretKey;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Check user credentials (in a real application, you'd authenticate against a database)
        if (model is { Username: "demo", Password: "password" })
        {
            // generate token for user
            var token = this.GenerateAccessToken(model.Username);

            // return access token for user's use
            return this.Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        // unauthorized user
        return this.Unauthorized("Invalid credentials");
    }

    private JwtSecurityToken GenerateAccessToken(string userName)
    {
        // Create user claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            // Add additional claims as needed (e.g., roles, etc.)
        };

        // Create a JWT
        var token = new JwtSecurityToken(
            issuer: this.issuer,
            audience: this.audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.secretKey)), SecurityAlgorithms.HmacSha256));

        return token;
    }
}

public class LoginModel
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
