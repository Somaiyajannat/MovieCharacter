global using MovieCharacter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MovieCharacter.Data;
using MovieCharacter.Services;

namespace MovieCharacter.Service{

    
    public class CharacterService : ICharacterService{

        private static  List<Character> characterList = new List<Character>{
            new Character{
                Id = 1, Name = "Somaiya Jannat"
            },
            new Character{
                Id = 2, Name = "Somaiya_2"
            }
        };

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService(IMapper mapper, DataContext context){
            _mapper = mapper;
            _context = context;
        }


        // get single character
        public async Task<ServiceResponse<CharacterDto>> getSingleCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            //var data = characterList.Where(x => x.Id == id).FirstOrDefault();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<CharacterDto>(dbCharacter);
            return serviceResponse;

        }

        // get all character
        public async Task<ServiceResponse<List<CharacterDto>>> getCharacter(){
            var serviceResponse = new ServiceResponse<List<CharacterDto>> ();
            var dbCharacters = await _context.Characters.ToListAsync();
            var data = dbCharacters.Select(c => _mapper.Map<CharacterDto>(c)).ToList();
            serviceResponse.Data = data;
            return serviceResponse;

        }

        // add a character

        public async Task<ServiceResponse<List<CharacterDto>>> addCharacter(CharacterDto NewCharacter){
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var character = _mapper.Map<Character>(NewCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            // character.Id = characterList.Max(c => c.Id) + 1;
            //characterList.Add(_mapper.Map<Character>(NewCharacter));
            serviceResponse.Data = await  _context.Characters.Select(c => _mapper.Map<CharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        // update a character

        public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(CharacterDto newCharacter){
            var serviceResponse = new ServiceResponse<CharacterDto>();

            try{    
                
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == newCharacter.Id);
                if(character is null){
                    throw new Exception($"Character with Id {newCharacter.Id} not found");
                }
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

        public async Task<ServiceResponse<CharacterDto>> DeleteCharacter(int id){

            var serviceResponse = new ServiceResponse<CharacterDto>();
            try{
                var info = characterList.Where(c => c.Id == id).FirstOrDefault();
                if (info is null) throw new Exception($"Character Id {id} is not found");

                characterList.Remove(info);

               // serviceResponse.Data = characterList.Select(c => _mapper.Map<CharacterDto>(c)).ToList();
                
            } catch (Exception ex){
                    serviceResponse.Status = false;
                    serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
                       

        }

    }
}        

   


    