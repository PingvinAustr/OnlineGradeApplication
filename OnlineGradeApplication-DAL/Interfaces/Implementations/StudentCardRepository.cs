using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class StudentCardRepository : IStudentCardRepository
    {

        public List<StudentCard> GetStudentCardsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.StudentCards.ToList();
        }
        public StudentCard GetStudentCardAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var studentCard = _context.StudentCards.FirstOrDefault(x => x.StudentCardId == id);
            return studentCard;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}
