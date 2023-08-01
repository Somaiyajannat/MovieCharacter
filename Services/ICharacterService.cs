global using MovieCharacter.Dto; 

namespace MovieCharacter.Service{

    public interface ICharacterService{
        List<CharacterDto> getCharcater();
        CharacterDto getSingleCharacter();
        CharacterDto getSingleCharacterById(int id);
        List<CharacterDto> addCharacter(CharacterDto newCharacter);

    }
}