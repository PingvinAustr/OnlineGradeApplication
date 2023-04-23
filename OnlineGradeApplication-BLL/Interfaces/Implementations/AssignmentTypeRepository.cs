using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class AssignmentTypeRepository : IAssignmentTypeRepository
    {
        private readonly IMapper _AssignmentTypeMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IAssignmentTypeRepository _assignmentType;

        public AssignmentTypeRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IAssignmentTypeRepository assignmentType)
        {
            _assignmentType = assignmentType;
            _AssignmentTypeMapper = mapper;
        }

        public List<AssignmentTypeDTO> GetAssignmentTypesAsync()
        {
            List<AssignmentType> assignmentsFromDB = _assignmentType.GetAssignmentTypesAsync();
            List<AssignmentTypeDTO> assignments = _AssignmentTypeMapper.Map<List<AssignmentType>, List<AssignmentTypeDTO>>(assignmentsFromDB);
            return assignments;
        }
        public AssignmentTypeDTO GetAssignmentTypeAsync(int id)
        {
            var data = _assignmentType.GetAssignmentTypeAsync(id);
            AssignmentTypeDTO assignmentType = _AssignmentTypeMapper.Map<AssignmentType, AssignmentTypeDTO>(data);
            return assignmentType;
        }
    }
}
