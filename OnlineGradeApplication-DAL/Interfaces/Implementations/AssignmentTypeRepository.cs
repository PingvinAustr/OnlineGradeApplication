using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class AssignmentTypeRepository : IAssignmentTypeRepository
    {
        public List<AssignmentType> GetAssignmentTypesAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.AssignmentTypes.ToList();
        }

        public AssignmentType GetAssignmentTypeAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            return _context.AssignmentTypes.FirstOrDefault(x => x.Id == id);
        }
    }
}
