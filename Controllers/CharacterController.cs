using Microsoft.AspNetCore.Mvc;
using MovieCharacter.Models;
using System;


namespace MovieCharacter.Controllers;

public class CharacterController: ControllerBase{


    private static Character charcaterList = new Character();


    [HttpGet]
    [Route("~/api/Index")]

    public async Task<ActionResult<string>> Index(){
        return Ok("Hello!");
    }

    [HttpGet]
    [Route("~/api/getAllCharacter")]

    public IActionResult getAllCharacter() {
        return Ok(charcaterList);
    }


}