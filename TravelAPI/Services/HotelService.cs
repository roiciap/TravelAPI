using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();
        List<Hotel> GetAvalibleHotels(HotelSearch search);
    }
    public class HotelService : IHotelService
    {
        private readonly DataBase _db;
        public HotelService(DataBase db)
        {
            _db= db;
        }
        public List<Hotel> GetAllHotels()
        {
            var a=_db.Hotele
                .Include(h=>h.Lokalizacja)
                .ToList();

            return a;
        }
        public List<Hotel> GetAvalibleHotels(HotelSearch search)
        {
            DateTime start = DateTime.Parse(search.odKiedy);
            DateTime end = DateTime.Parse(search.doKiedy);
            List<Hotel> ret;
            if (search.maxCost <= 0)
            {
                 ret = _db.Hotele.Include(h => h.Lokalizacja)
                    .ToList();
            }
            else
            {
                 ret = _db.Hotele
                    .Include(h => h.Lokalizacja)
                    .Where(h => h.koszt >= search.minCost && h.koszt <= search.maxCost)
                    .ToList();
            }

            foreach(var h in ret)
            {
                var wyc=_db.Wycieczki
                    .Where(w=>w.HotelId==h.Id &&
                    !(start>=w.DateEnd|| end <= w.DateStart))
                    .ToList();
                h.iloscPokoi = h.iloscPokoi - wyc.Count;
            }
            ret.RemoveAll(p=>p.iloscPokoi==0);
            return ret;
        }
    }
}
