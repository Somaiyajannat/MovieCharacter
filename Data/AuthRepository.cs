using Microsoft.IdentityModel.Tokens;
using MovieCharacter.Data;
using MovieCharacter.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieCharacter;
public class AuthRepository : IAuthRepository
{
    private readonly DataContext _datacontext;
    private readonly IConfiguration _configuration;
    public AuthRepository(DataContext dataContext, IConfiguration configuration)
    {
        _datacontext = dataContext;
        _configuration = configuration;
    }
    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await _datacontext.Users.FirstOrDefaultAsync(u => u.Username.ToLower() .Equals(username.ToLower()));
        if(user is null){
            response.Success = false;
            response.Message = "User not Found!";

        } else if (!VerifyPasswordHash(password,user.PasswordHash, user.PasswordSalt)){
            response.Success = false;
            response.Message = "Wrong password";
        } else {
            response.Data = CreateToken(user);
            //response.Data = user.Id.ToString();
        }
        return response;
       
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        var response = new ServiceResponse<int>();
        if(await UserExists(user.Username))
        {
            response.Success = false;
            response.Message = "User Already Exists";
            return response;
        }
        CreatePasswordHash( password,out byte[]passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _datacontext.Users.Add(user);
        await _datacontext.SaveChangesAsync();
        response.Data = user.Id;
        return response;
    }
    // check user exist or not
    public async Task<bool> UserExists(string username)
    {
        if(await _datacontext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower())){
            return true;
        }
        return false;
    }
// using an algothim for cryptography 
    private void CreatePasswordHash(string password,out byte[]passwordHash, out byte[] passwordSalt){
        using (var hmac = new System.Security.Cryptography.HMACSHA512()){
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    // check password correct or not

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
        using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
            var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return ComputeHash.SequenceEqual(passwordHash);
        }
    }
    // create token and return string
    private string CreateToken(User user){
        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };
        var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
        if(appSettingsToken is null)
        throw new Exception("App Settings token is null");

        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

         var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
         };
         JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
         SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

         return tokenHandler.WriteToken(token);

        //return string.Empty;
    }


}