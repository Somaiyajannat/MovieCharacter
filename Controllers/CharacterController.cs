global using MovieCharacter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCharacter.Service;
using MovieCharacter.Services;
using MovieCharacter.DTO;
namespace MovieCharacter.Controllers;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase {

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

        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> AddCharacter(AddCharacterDto newCharacter) {
            
            return Ok(await _charcaterService.addCharacter(newCharacter));
        }


        // update a character

        [HttpPut]
        [Route("~/api/updateCharacter")]

        public async Task<ActionResult<ServiceResponse<CharacterDto>>> updateCharacter(UpdateCharacterDto newCharacter) {
            var response = await _charcaterService.UpdateCharacter(newCharacter);
             if (response.Data is null)
            {
                return NotFound(response);
            }
             return Ok(response);
        }
        // delete a character

        [HttpDelete]
        [Route("~/api/deleteCharacter")]

        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> DeleteCharacter(int id){
            var response = await _charcaterService.DeleteCharacter(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("Skills")]
        public async Task<ActionResult<ServiceResponse<CharacterDto>>> AddCharacterSkill(AddCharacterSkillDto addCharcaterSkillDto){
            
            return Ok(await _charcaterService.AddCharacterSkill(addCharcaterSkillDto));
        }

    }
