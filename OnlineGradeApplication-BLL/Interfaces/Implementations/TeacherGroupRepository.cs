using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class TeacherGroupRepository : ITeachersGroupRepository
    {
        private readonly IMapper _TeacherGroupMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeachersGroupRepository _teachersGroups;

        public TeacherGroupRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeachersGroupRepository teachersGroups)
        {
            _teachersGroups = teachersGroups;
            _TeacherGroupMapper = mapper;
        }

        public List<TeachersGroupDTO> GetTeachersGroupsAsync()
        {
            List<TeachersGroup> teachersGroupsFromDB = _teachersGroups.GetTeachersGroupsAsync();
            List<TeachersGroupDTO> teachersGroups = _TeacherGroupMapper.Map<List<TeachersGroup>, List<TeachersGroupDTO>>(teachersGroupsFromDB);
            return teachersGroups;
        }
        public TeachersGroupDTO GetTeachersGroupAsync(int id)
        {
            var data = _teachersGroups.GetTeachersGroupAsync(id);
            TeachersGroupDTO teachersGroup = _TeacherGroupMapper.Map<TeachersGroup, TeachersGroupDTO>(data);
            return teachersGroup;
        }

        public void AddTeacherGroupEntry(TeachersGroupDTO group)
        {
            _teachersGroups.AddTeacherGroupEntry(_TeacherGroupMapper.Map<TeachersGroupDTO,TeachersGroup>(group));
        }
    }
}
