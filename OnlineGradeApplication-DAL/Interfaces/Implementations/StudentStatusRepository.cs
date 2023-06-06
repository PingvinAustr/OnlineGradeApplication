using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class StudentStatusRepository : IStudentStatusRepository
    {

        public List<StudentStatus> GetStudentStatusesAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.StudentStatuses.ToList();
        }
        public StudentStatus GetStudentStatusAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var studentStatus = _context.StudentStatuses.FirstOrDefault(x => x.Id == id);
            return studentStatus;
        }
    }
}
