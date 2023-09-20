using AutoMapper;
using MovieCharacter.DTO;
using MovieCharacter.Models;
using MovieCharacter.DTO.Weapon;
using MovieCharacter.DTO.Skill;
namespace MovieCharacter;

public class AutoMapperProfile : Profile {
    public AutoMapperProfile(){

        CreateMap<Character, CharacterDto>();
        CreateMap<CharacterDto, Character>();
        CreateMap<AddCharacterDto, AddCharacterDto>();
         CreateMap<Character, Character>();
        CreateMap<UpdateCharacterDto, Character>();
        CreateMap<Weapons, GetWeaponDto>();
        CreateMap<Weapons, AddWeaponDto>();
        CreateMap<Skill, GetSkillDto>();

    }

}