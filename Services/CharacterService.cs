global using MovieCharacter.Models;
global using MovieCharacter.DTO.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MovieCharacter.Data;
using MovieCharacter.Services;
using Azure;
namespace MovieCharacter.Service;

    
    public class CharacterService : ICharacterService{

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext context,IHttpContextAccessor httpContextAccessor){
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
         public int  GetUserID() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        
        // get all character
        public async Task<ServiceResponse<List<CharacterDto>>> getCharacter(){
            var serviceResponse = new ServiceResponse<List<CharacterDto>> ();
            var dbCharacters = await _context.Characters.
            Include(c => c.Weapon).
            Include(c => c.Skills).
            Where(c => c.User!.Id == GetUserID()).ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterDto>(c)).ToList();
            return serviceResponse;

        }
      
        // get single character
        public async Task<ServiceResponse<CharacterDto>> getSingleCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            var dbCharacter = await _context.Characters.
            Include(c => c.Weapon).
            Include(c => c.Skills).
            FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserID());
            serviceResponse.Data = _mapper.Map<CharacterDto>(dbCharacter);
            return serviceResponse;

        }


        // add a character

        public async Task<ServiceResponse<List<CharacterDto>>> addCharacter(AddCharacterDto NewCharacter){
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var character = _mapper.Map<Character>(NewCharacter);
             character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserID());

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Characters
            .Where(c => c.User!.Id == GetUserID())
            .Select(c => _mapper.Map<CharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }
 
        // update a character

        public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(UpdateCharacterDto newCharacter){
            var serviceResponse = new ServiceResponse<CharacterDto>();

            try{    
                
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == newCharacter.Id);
                // if(character == null || character.User!.Id ! = GetUserID()){
                //      throw new Exception("Charecter with Id '"+ newCharacter.Id+"' not found.");
                // }
                character.Id  = newCharacter.Id;
                character.Name = newCharacter.Name;
                character.Defense = newCharacter.Defense;
                character.Strength = newCharacter.Strength;
                character.HitPoints = newCharacter.HitPoints;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CharacterDto>(character);

            }
            catch(Exception ex){
                serviceResponse.Status = false;
                serviceResponse.Message = ex.Message;

            }
            
            return serviceResponse;

        }

        // delete character

        public async Task<ServiceResponse<List<CharacterDto>>> DeleteCharacter(int id){

            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            try{
                var info = _context.Characters.FirstOrDefault((c => c.Id == id && c.User!.Id == GetUserID()));
                if (info is null) throw new Exception($"Character Id {id} is not found");

                _context.Characters.Remove(info);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Characters.Select(c=>_mapper.Map<CharacterDto>(c)).ToList();

               // serviceResponse.Data = characterList.Select(c => _mapper.Map<CharacterDto>(c)).ToList();
                
            } catch (Exception ex){
                    serviceResponse.Status = false;
                    serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
                       

        }

// character skills
    public async Task<ServiceResponse<CharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
    {
        var serviceResponse = new ServiceResponse<CharacterDto>();
       try{
            var characters = await _context.Characters.
            Include(c => c.Weapon).
            Include(c => c.Skills).
            FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId &&  c.User!.Id == GetUserID());
            if(characters is null){
                serviceResponse.Status = false;
                serviceResponse.Message = "Character not Found!";

            }
            var skill = await _context.Skills.FirstOrDefaultAsync( s => s.Id == newCharacterSkill.SkillId);

            if(skill is null){
                serviceResponse.Status = false;
                serviceResponse.Message = "Skills not Found!";
                return serviceResponse;

            }
            characters.Skills!.Add(skill);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<CharacterDto>(characters);
            
                       

       } catch(Exception ex){
         serviceResponse.Status = false;
         serviceResponse.Message = ex.Message;
       }
       return serviceResponse;
    }
}
       

   


    