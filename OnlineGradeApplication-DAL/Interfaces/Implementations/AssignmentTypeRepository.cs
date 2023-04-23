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
        /*
        public async Task AddAssignmentTypeAsync(AssignmentType assignmentType)
        {
            _context.AssignmentTypes.Add(assignmentType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssignmentTypeAsync(AssignmentType assignmentType)
        {
            _context.Entry(assignmentType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentTypeAsync(int id)
        {
            var assignmentType = await _context.AssignmentTypes.FindAsync(id);
            if (assignmentType != null)
            {
                _context.AssignmentTypes.Remove(assignmentType);
                await _context.SaveChangesAsync();
            }
        }
        */
    }
}
