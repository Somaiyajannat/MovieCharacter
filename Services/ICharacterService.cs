global using MovieCharacter.Dto; 

namespace MovieCharacter.Service{

    public interface ICharacterService{
        List<CharacterDto> getCharacter();
        CharacterDto getSingleCharacter(int id);

        List<Character> addCharacter(Character newCharacter);

    }
}