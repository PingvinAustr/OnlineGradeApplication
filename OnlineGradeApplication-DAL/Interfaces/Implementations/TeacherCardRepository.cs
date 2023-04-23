using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class TeacherCardRepository : ITeacherCardRepository
    {

        public List<TeacherCard> GetTeacherCardsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.TeacherCards.ToList();
        }
        public TeacherCard GetTeacherCardAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var teacherCard = _context.TeacherCards.FirstOrDefault(x => x.Id == id);
            return teacherCard;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}
