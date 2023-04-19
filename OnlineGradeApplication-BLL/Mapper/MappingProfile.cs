using AutoMapper;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}