using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class StudentAssignmentRepository : IStudentAssignmentRepository
    {
        private readonly IMapper _IStudentAssignmentMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentAssignmentRepository _studentAssignment;

        public StudentAssignmentRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentAssignmentRepository studentAssignment)
        {
            _studentAssignment = studentAssignment;
            _IStudentAssignmentMapper = mapper;
        }

        public List<StudentAssignmentDTO> GetStudentAssignmentsAsync()
        {
            List<StudentAssignment> studentAssignmentsFromDB = _studentAssignment.GetStudentAssignmentsAsync();
            List<StudentAssignmentDTO> studentAssignments = _IStudentAssignmentMapper.Map<List<StudentAssignment>, List<StudentAssignmentDTO>>(studentAssignmentsFromDB);
            return studentAssignments;
        }
        public StudentAssignmentDTO GetStudentAssignmentAsync(int id)
        {
            var data = _studentAssignment.GetStudentAssignmentAsync(id);
            StudentAssignmentDTO studentAssignment = _IStudentAssignmentMapper.Map<StudentAssignment, StudentAssignmentDTO>(data);
            return studentAssignment;
        }
    }
}
