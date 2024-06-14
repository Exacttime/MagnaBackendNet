using AutoMapper;
using MagnaBackendNet.domain.models;
using MagnaBackendNet.Domain.DTO;
using System.Diagnostics.Metrics;

namespace MagnaBackendNet.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Manga, MangaDTO>();
            CreateMap<MangaDTO, Manga>();

        }
    }
}
