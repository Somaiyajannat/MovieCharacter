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

        public List<Character> getCharcater()
        {
            return characters;
        }

        public Character getSingleCharacter()
        {
            return characters[0];
        }

        public Character getSingleCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }

        public List<Character> addCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

   


    }
}