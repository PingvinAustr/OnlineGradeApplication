using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class TeacherPositionRepository : ITeacherPositionRepository
    {

        public List<TeacherPosition> GetTeacherPositionsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.TeacherPositions.ToList();
        }
        public TeacherPosition GetTeacherPositionAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var teacherPosition = _context.TeacherPositions.FirstOrDefault(x => x.Id == id);
            return teacherPosition;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}
