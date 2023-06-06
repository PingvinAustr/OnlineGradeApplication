using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class StudentsGroupsRepository : IStudentsGroupRepository
    {

        public List<StudentsGroup> GetStudentsGroupsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.StudentsGroups.ToList();
        }
        public StudentsGroup GetStudentsGroupAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var studentsGroup = _context.StudentsGroups.FirstOrDefault(x => x.Id == id);
            return studentsGroup;
        }
    }
}
