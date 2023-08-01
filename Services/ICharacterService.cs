namespace MovieCharacter.Service{

    public interface ICharacterService{
        List<Character> getCharcater();
        Character getSingleCharacter();
        Character getSingleCharacterById(int id);
        List<Character> addCharacter(Character newCharacter);

    }
}