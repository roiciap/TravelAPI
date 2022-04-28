using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        public KlientController(DataBase db,IMapper mapper,IAccountService service)
        {
            _mapper = mapper;
            _service = service;
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
    }
}
