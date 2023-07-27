using Microsoft.AspNetCore.Mvc;

namespace MovieCharacter.Controllers;

public class CharacterController: ControllerBase{


    [HttpGet]
    [Route("~/api/Index")]

    public async Task<ActionResult<string>> Index(){
        return Ok("Hello!");
    }

}