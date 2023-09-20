
global using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MovieCharacter.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options ): base(options){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        //base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Skill>().HasData(
            new Skill{
                Id = 1, Name = "Fireball", Damage = 20
            },
            new Skill{
                Id = 2, Name = "Fireball_1", Damage = 20
            },
            new Skill{
                Id = 3, Name = "Fireball_3", Damage = 20
            }
        );
    }
    

    public DbSet <Character> Characters => Set<Character>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Weapons> Weapons => Set<Weapons>();
    public DbSet<Skill> Skills => Set<Skill>();
}
