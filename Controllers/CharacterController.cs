global using MovieCharacter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCharacter.Service;
using MovieCharacter.Services;

namespace MovieCharacter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase{

        private static  ICharacterService _charcaterService; 
            
        public CharacterController(ICharacterService characterservice){
            _charcaterService = characterservice;
        }
       

        // get all character
        [HttpGet]
        [Route("~/api/getAallCharacter")]

        public async  Task<ActionResult<ServiceResponse<List<CharacterDto>>>>  GetCharacter(){
            return Ok(await _charcaterService.getCharacter());
        }
        // get single

        [HttpGet]
        [Route("~/api/getSingleCharacter/{id}")]

        public async Task<ActionResult<ServiceResponse<CharacterDto>>> GetSingleCharacter(int id){

            return Ok(await _charcaterService.getSingleCharacter(id));
        }

     
        // add a charcater 
        [HttpPost]
        [Route("~/api/addCharacter")]

        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(CharacterDto newCharacter) {
            
            return Ok(await _charcaterService.addCharacter(newCharacter));
        }

    }
}