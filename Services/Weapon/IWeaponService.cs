using MovieCharacter.DTO.Weapon;

namespace MovieCharacter.Services.Weapon;


public interface IWeaponService
{
    Task<ServiceResponse<Character>> AddWeapon(AddWeaponDto newWeapon);
}
