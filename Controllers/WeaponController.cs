using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MovieCharacter.Data;
using MovieCharacter.DTO.Weapon;
using MovieCharacter.Services.Weapon;
using MovieCharacter.Services;
namespace MovieCharacter.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class WeaponController: ControllerBase{
        private readonly IWeaponService _weaponService;
        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;            
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
        {
            return Ok(await _weaponService.AddWeapon(newWeapon));
        }


}