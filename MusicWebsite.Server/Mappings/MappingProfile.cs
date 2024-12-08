using AutoMapper;
using MusicWebsite.Server.DTO;
using MusicWebsite.Server.Models;

namespace MusicWebsite.Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Track, TrackDTO>();
            CreateMap<Playlist, PlaylistDTO>();
        }
    }
}