
using System;

namespace MovieCharacter.Dto{
    public class CharacterDto{
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 100;
        public int Defense { get; set; } = 100;
        public int Intelligence { get; set; } = 100;
        public RpgClass Category { get; set; } = new RpgClass();
    }
}