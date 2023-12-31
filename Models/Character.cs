

namespace MovieCharacter.Models{

    public class Character{
        
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 100;
        public int Defense { get; set; } = 100;
        public int Intelligence { get; set; } = 100;
        public RpgClass Category { get; set; } = RpgClass.Knight;
        public User? User{get;set;}
        public Weapons? Weapon{get;set;}

        public List<Skill>? Skills{get;set;}

    }

}

