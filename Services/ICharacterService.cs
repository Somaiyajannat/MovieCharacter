global using MovieCharacter.Dto; 
using MovieCharacter.Services;

namespace MovieCharacter.Service;

    public interface ICharacterService{
        Task<ServiceResponse<List<CharacterDto>>> getCharacter();
        Task<ServiceResponse<CharacterDto>> getSingleCharacter(int id);
        Task <ServiceResponse<CharacterDto>> UpdateCharacter(CharacterDto newCharacter);
        Task<ServiceResponse<List<CharacterDto>>> addCharacter(CharacterDto newCharacter);

        Task<ServiceResponse<List<CharacterDto>>> DeleteCharacter(int id);

    }
