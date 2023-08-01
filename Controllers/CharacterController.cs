global using MovieCharacter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCharacter.Service;


namespace MovieCharacter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase{
        private static  ICharacterService _charcaterService; 

        public CharacterController(ICharacterService characterservice){
            _charcaterService = characterservice;
        }
       


        [HttpGet]
        [Route("~/api/getAallCharacter")]

        public ActionResult<List<Character>>  getCharcater(){
            return Ok(_charcaterService.getCharcater());
        }
        // get single

        [HttpGet]
        [Route("~/api/getSingleCharacter")]

        public ActionResult<Character> getSingleCharacter() {
            return Ok(_charcaterService.getSingleCharacter());
        }

        // get single charcater by id

        [HttpGet]
        [Route("~/api/getSingleCharacterById/{id}")]

        public ActionResult<Character> getSingleCharacterById(int id){
            return Ok(_charcaterService.getSingleCharacterById(id));
        }
        // add a charcater 
        [HttpPost]
        [Route("~/api/addCharacter")]

        public ActionResult<List<Character>> addCharacter(Character newCharacter) {
            
            return Ok(_charcaterService.addCharacter(newCharacter));
        }

    }
}