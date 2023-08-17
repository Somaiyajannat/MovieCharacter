using Microsoft.AspNetCore.Mvc;
using MovieCharacter.Data;
using MovieCharacter.DTO.User;
using MovieCharacter.Services;

namespace MovieCharacter.Controllers;

[ApiController]
[Route("api/[controller]")]


public class AuthController: ControllerBase{
    private readonly IAuthRepository _authrepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authrepository = authRepository;
    }
    [HttpPost]
    [Route("~/api/user/registration")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request){
        var response = await _authrepository.Register(
            new User{Username = request.Username},
            request.Password
        );
        if(!response.Status){
            return BadRequest(response);
        }
        return Ok(response);

        
    }

}