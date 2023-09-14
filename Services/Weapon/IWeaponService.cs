using MovieCharacter.DTO.Weapon;

namespace MovieCharacter.Services.Weapon;


public interface IWeaponService
{
    Task<ServiceResponse<CharacterDto>> AddWeapon(AddWeaponDto newWeapon);
}
