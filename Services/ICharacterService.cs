global using MovieCharacter.DTO; 
using MovieCharacter.Services;

namespace MovieCharacter.Service;

    public interface ICharacterService{
        Task<ServiceResponse<List<CharacterDto>>> getCharacter();

        Task<ServiceResponse<CharacterDto>> getSingleCharacter(int id);
         Task <ServiceResponse<CharacterDto>> UpdateCharacter(UpdateCharacterDto newCharacter);
        Task<ServiceResponse<List<CharacterDto>>> addCharacter(AddCharacterDto newCharacter);

        Task<ServiceResponse<List<CharacterDto>>> DeleteCharacter(int id);
        Task<ServiceResponse<CharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);

    }
