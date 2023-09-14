using AutoMapper;
using MovieCharacter.DTO;
using MovieCharacter.Models;
using MovieCharacter.DTO.Weapon;
namespace MovieCharacter;

public class AutoMapperProfile : Profile {
    public AutoMapperProfile(){

        CreateMap<Character, CharacterDto>();
        CreateMap<CharacterDto, Character>();
        CreateMap<AddCharacterDto, Character>();
        CreateMap<UpdateCharacterDto, Character>();
        CreateMap<Weapons, GetWeaponDto>();
        CreateMap<Weapons, AddWeaponDto>();
    }

}