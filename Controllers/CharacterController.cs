global using MovieCharacter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MovieCharacter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase{
        private static readonly List<Character> characters = new List<Character>{
            new Character(),
            new Character{
                Id = 1, Name = "Somaiya"
            }
        };


        [HttpGet]
        [Route("~/api/getAallCharacter")]

        public ActionResult<List<Character>>  getCharcater(){
            return Ok(characters);
        }

       
       
            

    }
}