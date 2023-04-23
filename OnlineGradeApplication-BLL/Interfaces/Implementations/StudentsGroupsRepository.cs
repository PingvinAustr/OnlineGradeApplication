using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class StudentsGroupsRepository : IStudentGroupsRepository
    {
        private readonly IMapper _StudentsGroupsMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentsGroupRepository _studentGroups;

        public StudentsGroupsRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentsGroupRepository studentGroups)
        {
            _studentGroups = studentGroups;
            _StudentsGroupsMapper = mapper;
        }

        public List<StudentsGroupDTO> GetStudentsGroupsAsync()
        {
            List<StudentsGroup> studentGroupsFromDB = _studentGroups.GetStudentsGroupsAsync();
            List<StudentsGroupDTO> studentsGroups = _StudentsGroupsMapper.Map<List<StudentsGroup>, List<StudentsGroupDTO>>(studentGroupsFromDB);
            return studentsGroups;
        }
        public StudentsGroupDTO GetStudentsGroupAsync(int id)
        {
            var data = _studentGroups.GetStudentsGroupAsync(id);
            StudentsGroupDTO studentsGroup = _StudentsGroupsMapper.Map<StudentsGroup, StudentsGroupDTO>(data);
            return studentsGroup;
        }
    }
}
