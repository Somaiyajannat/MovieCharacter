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
      
        public CharacterDto getSingleCharacter(int id)
        {
            
            var item = characters.Where(c =>c.Id == id).FirstOrDefault();
            CharacterDto cdtos = new CharacterDto();
           if(item != null){

                cdtos.Name = item.Name;
                cdtos.Id = item.Id;
                cdtos.Category = item.Category;
                cdtos.Intelligence = item.Intelligence;
                cdtos.HitPoints = item.HitPoints;
           }
             
            
            return cdtos;
        }
  
        public List<Character> addCharacter(Character newCharacter)
        {
            Character c = new Character();
            c.Category = newCharacter.Category;
            c.Id = newCharacter.Id;
            c.Name = newCharacter.Name;


            characters.Add(c);
            return characters;
        }

       
    }
}        

   


    