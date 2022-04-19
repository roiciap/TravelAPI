using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI.Controllers
{
    public class KlientController : Controller
    {
        private readonly DataBase _db;
        private readonly IMapper _mapper;

        public KlientController(DataBase db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("/api/all/klient")]
        public ActionResult<IEnumerable<KlientDto>> getAll()
        {
            var klients = _db
                .Klienci
                .ToList();

            var klientsDto=_mapper.Map<List<KlientDto>>(klients);
            return Ok(klientsDto);
        }
        [HttpGet("/api/klient/{id}")]
        public ActionResult<IEnumerable<KlientDto>> getById([FromRoute]int id)
        {
            var k = _db
                .Klienci
                .SingleOrDefault(k=>k.Id==id);

            var result = _mapper.Map<KlientDto>(k);
            return Ok(result);
        }
    }
}
