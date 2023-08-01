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
        // get single

        [HttpGet]
        [Route("~/api/getSingleCharacter")]

        public ActionResult<Character> getSingleCharacter() {
            return Ok(characters[1]);
        }

        // get single charcater by id

        [HttpGet]
        [Route("~/api/getSingleCharacterById/{id}")]

        public ActionResult<Character> getSingleCharacterById(int id){
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
        // add a charcater 
        [HttpPost]
        [Route("~/api/addCharacter")]

        public ActionResult<List<Character>> addCharacter(Character newCharacter) {
            characters.Add(newCharacter);
            return Ok(characters);
        }


       
       
            

    }
}