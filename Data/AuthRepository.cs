using MovieCharacter.Data;
using MovieCharacter.Services;

namespace MovieCharacter;
public class AuthRepository : IAuthRepository
{
    private readonly DataContext _datacontext;
    public AuthRepository(DataContext dataContext)
    {
        _datacontext = dataContext;
    }
    public Task<ServiceResponse<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        _datacontext.Users.Add(user);
        await _datacontext.SaveChangesAsync();
        var response = new ServiceResponse<int>();
        response.Data = user.Id;
        return response;
    }

    public Task<bool> UserExists(string username)
    {
        throw new NotImplementedException();
    }
// using an algothim for cryptography 
    private void CreatePasswordHash(string password,out byte[]passwordHash, out byte[] passwordSalt){
        using (var hmac = new System.Security.Cryptography.HMACSHA512()){
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}