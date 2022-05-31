using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TravelAPI.Entities;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class KlientController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IAccountService _service;
        private readonly IRezerwacjaService _rezerwacjaService;

        public KlientController(DataBase db,IMapper mapper,IAccountService service,IRezerwacjaService rService)
        {
            _mapper = mapper;
            _service = service;
            _rezerwacjaService = rService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterKlientDto user )
        {
            if(_service.RegisterUser(user))
                return Ok();
            return BadRequest();
        }
        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] LoginDto user)
        {
            var ret = _service.LoginUser(user);
            if (ret != null)
                return Ok(ret);

            return BadRequest();
        }

        [HttpGet("check")]
        [Authorize]
        public ActionResult check()
        {
            return Ok();
        }

        [HttpPost("add")]
        [Authorize]
        public ActionResult AddRezerwacja([FromBody]RezerwacjaWycieczkiDto[] rezerwacja)
        {
            // var xd = HttpContext.;
            // User.Claims.
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            System.Diagnostics.Debug.WriteLine("Co to bedzie?");
            if (_rezerwacjaService.Add(rezerwacja, User))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
//HttpContext.User.IsInRole("admin")
//[Authorize(Roles="admin")] 