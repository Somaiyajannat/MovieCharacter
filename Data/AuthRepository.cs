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
        var response = new ServiceResponse<int>();
        if(await UserExists(user.Username))
        {
            response.Status = false;
            response.Message = "User Already exists";
            return response;
        }
        CreatePasswordHash( password,out byte[]passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        // add new user to Users-> then save it to the database
        _datacontext.Users.Add(user);
        await _datacontext.SaveChangesAsync();
        // send id to the generic class serviceresponse 
        // if send password it word save as a plain text which is not good
        // we use an algorithm for create password
        response.Data = user.Id;
        return response;
    }

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
}