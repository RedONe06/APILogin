using API_Login.Data.DTO;
using API_Login.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API_Login.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();

        }
    }
}
