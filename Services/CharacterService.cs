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
    }
}        

   


    