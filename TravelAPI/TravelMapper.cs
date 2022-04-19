using AutoMapper;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI
{
    public class TravelMapper : Profile
    {
        public TravelMapper()
        {
            CreateMap<Klient, KlientDto>();

            CreateMap<Rezerwacja, RezerwacjaDto>();

            CreateMap<Wycieczka, WycieczkaDto>();

            CreateMap<Pokoj, PokojDto>()
                .ForMember(pd => pd.NazwaHotelu, p => p.MapFrom(h => h.Hotel.Nazwa));

            CreateMap<Hotel, HotelDto>();
        }
    }
}
