global using MovieCharacter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharacter.Service{

    
    public class CharacterService : ICharacterService{

        private static readonly List<Character> characters = new List<Character>{
            new Character(),
            new Character{
                Id = 1, Name = "Somaiya"
            }
        };

        public List<CharacterDto> getCharacter()
        {
            List<CharacterDto> characterDtos = new List<CharacterDto>();
            
            foreach(var item in characters){
                CharacterDto newItem = new CharacterDto();
                newItem.Category = item.Category;
                newItem.Name = item.Name;
                newItem.Defense = item.Defense;

                characterDtos.Add(newItem);
            }

            return characterDtos;
        }

        public Character getSingleCharacter()
        {
            return characters[0];
        }

        public Character getSingleCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }

        public List<CharacterDto> addCharacter(CharacterDto newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

   


    }
}