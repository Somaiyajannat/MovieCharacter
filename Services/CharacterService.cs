global using MovieCharacter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieCharacter.Services;

namespace MovieCharacter.Service{

    
    public class CharacterService : ICharacterService{

        private static  List<Character> characterList = new List<Character>{
            new Character(),
            new Character{
                Id = 1, Name = "Somaiya"
            }
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper){
            _mapper = mapper;
        }


        // get single character
        public async Task<ServiceResponse<CharacterDto>> getSingleCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            var data = characterList.Where(x => x.Id == id).FirstOrDefault();
            serviceResponse.Data = _mapper.Map<CharacterDto>(data);
            return serviceResponse;

        }

        // get all character
        public async Task<ServiceResponse<List<CharacterDto>>> getCharacter(){
            var serviceResponse = new ServiceResponse<List<CharacterDto>> ();
            var data = characterList.Select(c => _mapper.Map<CharacterDto>(c)).ToList();
            serviceResponse.Data = data;
            return serviceResponse;

        }

        // add a character

        public async Task<ServiceResponse<List<CharacterDto>>> addCharacter(CharacterDto NewCharacter){
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var character = _mapper.Map<Character>(NewCharacter);
            character.Id = characterList.Max(c => c.Id) + 1;
            characterList.Add(_mapper.Map<Character>(NewCharacter));
            serviceResponse.Data = characterList.Select(c => _mapper.Map<CharacterDto>(c)).ToList();
            return serviceResponse;
        }

        // update a character

        public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(CharacterDto newCharacter){
            var serviceResponse = new ServiceResponse<CharacterDto>();

            try{    
                
                var character = characterList.FirstOrDefault(c => c.Id == newCharacter.Id);
                if(character is null){
                    throw new Exception($"Character with Id {newCharacter.Id} not found");
                }
                character.Id  = newCharacter.Id;
                character.Name = newCharacter.Name;
                character.Defense = newCharacter.Defense;
                character.Strength = newCharacter.Strength;
                character.HitPoints = newCharacter.HitPoints;
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

   


    