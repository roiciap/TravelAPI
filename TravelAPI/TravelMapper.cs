using AutoMapper;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI
{
    public class TravelMapper : Profile
    {
        public TravelMapper()
        {
            CreateMap<Klient, LoginDto>();

            CreateMap<Rezerwacja, RezerwacjaDto>();

            CreateMap<Wycieczka, WycieczkaDto>();

            CreateMap<Hotel, HotelDto>()
                .ForMember(h => h.Miasto, d => d.MapFrom(l => l.Lokalizacja.Miasto))
                .ForMember(h => h.Kraj, d => d.MapFrom(l => l.Lokalizacja.Kraj));
        }
    }
}
