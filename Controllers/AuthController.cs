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
    // registration
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
    // login
    [HttpPost]
    [Route("~/api/user/login")]
    public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request){
        var response = await _authrepository.Login(request.Username, request.Password);
        if(!response.Status){
            return BadRequest(response);
        }
        return Ok(response);

        
    }


}