using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelAPI.Authorization;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface IRezerwacjaService
    {
        bool check(int id, RezerwacjaDto dto, ClaimsPrincipal user);
         bool Add(RezerwacjaWycieczkiDto[] rezerwacja, ClaimsPrincipal user);
    }
    public class RezerwacjaService : IRezerwacjaService
    {
        private readonly DataBase _db;
        private readonly IAuthorizationService _authorization;
        public RezerwacjaService(DataBase db,IAuthorizationService authorization)
        {
            _db = db;
            _authorization = authorization;
        }
        public bool check(int id, RezerwacjaDto dto, ClaimsPrincipal user)
        {
            var rezerwacja = _db.Rezerwacje.FirstOrDefault(r=>r.Id==dto.Id);
            if (rezerwacja == null)
            {
                return false;
            }
            var authorizationResult = _authorization.AuthorizeAsync(user, rezerwacja, new UserIdOperationRequirement(UserOperation.DeleteRezerwacja)).Result;
            if (!authorizationResult.Succeeded)
            {
                return false;
            }
            return true;
        }

        public bool Add(RezerwacjaWycieczkiDto[] rezerwacja,ClaimsPrincipal user)
        {
            int iloscDodanych = 0;
            var nowaRezerwacja = new Rezerwacja()
            {
                KlientId = int.Parse(user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                Cost = 500,
                PaymentExpires = DateTime.Now,
                Paid = false,
            };
            _db.Rezerwacje.Add(nowaRezerwacja);
            _db.SaveChanges();

            foreach (var w in rezerwacja)
            {
                var start = DateTime.Parse(w.start);
                var end = DateTime.Parse(w.end);
                int TakenRooms=_db.Wycieczki.Where(x=>x.HotelId==w.Id && !(start>x.DateEnd || end<x.DateStart)).ToList().Count;
                int avaliableRooms = _db.Hotele.SingleOrDefault(h => h.Id == w.Id).iloscPokoi;
                System.Diagnostics.Debug.WriteLine("ilosc dostepnych pokoi hotelu(" + w.Id + ") : " + avaliableRooms + " Ilosc zabranych : " +TakenRooms);
                if (avaliableRooms-TakenRooms  > 0)
                {
                    iloscDodanych++;
                    _db.Wycieczki.Add(new Wycieczka()
                    {
                        DateStart = start,
                        DateEnd = end,
                        HotelId=w.Id,
                        RezerwacjaId=nowaRezerwacja.Id,
                    });
                }
            }
            if (iloscDodanych > 0)
            {
                _db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Dobrze");
            }
            else
            {
                _db.Rezerwacje.Remove(nowaRezerwacja);
                _db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Zle");
            }
            return true;


        }

    }
}
