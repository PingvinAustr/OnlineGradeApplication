using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class StudentMarkRepository : IStudentMarkRepository
    {

        public List<StudentMark> GetStudentMarksAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.StudentMarks.ToList();
        }
        public StudentMark GetStudentMarkAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var studentMark = _context.StudentMarks.FirstOrDefault(x => x.Id == id);
            return studentMark;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}
