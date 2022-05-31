using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TravelAPI.Entities;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controllers
{
    [Route("hotel")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHotelService _service;
        public HotelController(DataBase db, IMapper mapper, IHotelService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IActionResult Index()
        {
            return Ok();
        }
        [HttpGet("get")]
        public ActionResult<IEnumerable<List<HotelDto>>> getHotels()
        {
            var hotele = _service.GetAllHotels();
            
            var ret = _mapper.Map<List<HotelDto>>(hotele);
            return Ok(ret);
        }
        [HttpGet("get/search")]
        public IActionResult getHotels2([FromBody]HotelSearch search)
        {
            if (search == null)
            {
                return BadRequest();
            }

            var start = DateTime.Parse(search.odKiedy);
            var end = DateTime.Parse(search.doKiedy);
            if(start > end)
            {
                return BadRequest();
            }

            var hotele = _service.GetAvalibleHotels(search);

            var ret = _mapper.Map<List<HotelDto>>(hotele);
            return Ok(ret);
        }
    }
}
