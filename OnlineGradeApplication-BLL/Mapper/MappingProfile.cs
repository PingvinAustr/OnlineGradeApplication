﻿using AutoMapper;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<AssignmentType, AssignmentTypeDTO>().ReverseMap();
            CreateMap<Cafedra, CafedraDTO>().ReverseMap();
            CreateMap<Discipline, DisciplineDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<StudentAssignment, StudentAssignmentDTO>().ReverseMap();
            CreateMap<StudentCard, StudentCardDTO>().ReverseMap();
            CreateMap<StudentMark, StudentMarkDTO>().ReverseMap();
            CreateMap<StudentsGroup, StudentsGroupDTO>().ReverseMap();
            CreateMap<StudentStatus, StudentStatusDTO>().ReverseMap();
            CreateMap<SystemAccess, SystemAccessDTO>().ReverseMap();
            CreateMap<TeacherCard, TeacherCardDTO>().ReverseMap();
            CreateMap<TeacherPosition, TeacherPositionDTO>().ReverseMap();
            CreateMap<TeachersGroup, TeachersGroupDTO>().ReverseMap();
        }
    }
}