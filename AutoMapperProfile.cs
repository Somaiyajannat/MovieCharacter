using AutoMapper;
using MovieCharacter.Dto;
using MovieCharacter.Models;
namespace MovieCharacter;

public class AutoMapperProfile : Profile {
    public AutoMapperProfile(){

        CreateMap<Character, CharacterDto>();
        CreateMap<CharacterDto, Character>();
    }

}