using AutoMapper;
using Entity.Dtos.ClientDTO;
using Entity.Dtos.ProductDTO;
using Entity.Model;

namespace Business.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClientDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre))
                .ReverseMap();

            CreateMap<Pedido, PedidoDto>().ReverseMap();
        }
    }
}
