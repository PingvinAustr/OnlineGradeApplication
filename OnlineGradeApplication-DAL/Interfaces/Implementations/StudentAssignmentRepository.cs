using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class StudentAssignmentRepository : IStudentAssignmentRepository
    {

        public List<StudentAssignment> GetStudentAssignmentsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.StudentAssignments.ToList();
        }
        public StudentAssignment GetStudentAssignmentAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var studentAssignment = _context.StudentAssignments.FirstOrDefault(x => x.Id == id);
            return studentAssignment;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}
