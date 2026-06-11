using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Starwars.Auth.Api;

var builder = WebApplication.CreateBuilder(args);


//Config
var jwtKey    = builder.Configuration["Jwt:Key"]!;
var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;
var jwtAud    = builder.Configuration["Jwt:Audience"]!;
var jwtExpMin = int.Parse(builder.Configuration["Jwt:ExpiresInMinutes"]!);

//Config Auth
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = jwtIssuer,
            ValidAudience            = jwtAud,
            IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();




app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
    
//Middleware Demo1
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Demo1 Request {context.Request.Method} {context.Request.Path}");
    
    await next();

    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Demo1 Response {context.Response.StatusCode}");
});


//Middleware Demo2
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Demo2 Request {context.Request.Method} {context.Request.Path}");

    await next();

    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Demo2 Response {context.Response.StatusCode}");
});


// POST /api/auth/token — valida user/pass y devuelve JWT
// Regla: password == reverse(user), case-insensitive
app.MapPost("/api/auth/token", (LoginRequest req) =>
{
    var username     = req.Username?.Trim() ?? "";
    var pass     = req.Password?.Trim() ?? "";

    
    var authService = new AuthService();

    //Opcion 1: Validar con la regla de negocio directamente en el endpoint
    //var reversed = new string(username.ToLower().Reverse().ToArray());
    //if (string.IsNullOrEmpty(user)
    //   || !pass.Equals(reversed, StringComparison.OrdinalIgnoreCase))
    //    return Results.Unauthorized();


    //Get user from DB (simulated)
    var userData = GetUserFromDb(username);

    if (userData is null 
        || !authService.IsValid(userData, pass)) { 
        return Results.Unauthorized();
    }

   

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, userData.Username),
        new Claim(ClaimTypes.Role, "User"),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
    
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
    var token = new JwtSecurityToken(
        issuer:             jwtIssuer,
        audience:           jwtAud,
        claims:             claims,
        expires:            DateTime.UtcNow.AddMinutes(jwtExpMin),
        signingCredentials: creds);

    return Results.Ok(new
    {
        token   = new JwtSecurityTokenHandler().WriteToken(token),
        expires = token.ValidTo
    });
});

 User GetUserFromDb(string username)
{
    var passOriginal = "123456";
    var salt = Encoding.UTF8.GetBytes("X");
    var passOriginalHash = PasswordSha256.HashPassword(passOriginal, salt);

    var userData = new User()
    {
        PasswordHash = Encoding.UTF8.GetBytes(passOriginalHash),
        Salt = Encoding.UTF8.GetBytes("X")
    };

    return userData;
}

// GET /api/time — público, sin autenticación
app.MapGet("/api/time", () =>
    Results.Ok(new 
        { 
            time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            secured = false,
            user = string.Empty
        }));

// GET /api/time/secure — requiere JWT válido
app.MapGet("/api/time/secure", (ClaimsPrincipal user) =>
    Results.Ok(new
    {
        time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        secured = true,
        user = user.Identity?.Name
    }))
    .RequireAuthorization();

app.Run();

