using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;
using OnlineGradeApplication_BLL.Responses;
using OnlineGradeApplication_DAL.Responses;

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

        public List<OnlineGradeApplication_BLL.Responses.StudentAssignmentResponse> GetStudentAssignmentsByStudentId(int studentId)
        {
            var data = _studentAssignment.GetStudentAssignmentsByStudentId(studentId);
            List < OnlineGradeApplication_BLL.Responses.StudentAssignmentResponse > studentAssignmentResponses = _IStudentAssignmentMapper.Map<List<OnlineGradeApplication_DAL.Responses.StudentAssignmentResponse>, List<OnlineGradeApplication_BLL.Responses.StudentAssignmentResponse>>(data);
            return studentAssignmentResponses;
        }

        public List<OnlineGradeApplication_BLL.Responses.TeacherAssignmentResponse> GetTeacherAssignmentsByStudentId(int teacherId)
        {
            var data = _studentAssignment.GetTeacherAssignmentsByStudentId(teacherId);
            List<OnlineGradeApplication_BLL.Responses.TeacherAssignmentResponse> studentAssignmentResponses = _IStudentAssignmentMapper.Map<List<OnlineGradeApplication_DAL.Responses.TeacherAssignmentResponse>, List<OnlineGradeApplication_BLL.Responses.TeacherAssignmentResponse>>(data);
            return studentAssignmentResponses;
        }
    }
}
