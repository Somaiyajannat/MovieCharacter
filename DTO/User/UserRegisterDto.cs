using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MovieCharacter.DTO.User;

public class UserRegisterDto
{
    public string Username { get; set; } = string.Empty;
    public string Password{get;set;} = string.Empty;

}
