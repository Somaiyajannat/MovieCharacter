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

        public ActionResult<List<CharacterDto>>  getCharacter(){
            return Ok(_charcaterService.getCharacter());
        }
        // get single

        [HttpGet]
        [Route("~/api/getSingleCharacter/{id}")]

        public ActionResult<CharacterDto> getSingleCharacter(int id){

            return Ok(_charcaterService.getSingleCharacter(id));
        }

     
        // add a charcater 
        [HttpPost]
        [Route("~/api/addCharacter")]

        public ActionResult<List<Character>> addCharacter(Character newCharacter) {
            
            return Ok(_charcaterService.addCharacter(newCharacter));
        }

    }
}