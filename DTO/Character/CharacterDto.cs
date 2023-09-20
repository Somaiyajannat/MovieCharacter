
using System;
using MovieCharacter.DTO.Skill;
using MovieCharacter.DTO.Weapon;

namespace MovieCharacter.DTO.Character;
    public class CharacterDto{
        public int Id {get;set;}
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 100;
        public int Defense { get; set; } = 100;
        public int Intelligence { get; set; } = 100;
        public RpgClass Category { get; set; } = new RpgClass();
        public GetWeaponDto? Weapon {get;set;} 
        public List<GetSkillDto>? Skills{get;set;}
    }
