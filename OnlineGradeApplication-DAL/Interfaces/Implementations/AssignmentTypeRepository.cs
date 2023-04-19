using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class AssignmentTypeRepository : IAssignmentTypeRepository
    {
        private readonly OnlineGradesDbContext _context;

        public AssignmentTypeRepository(OnlineGradesDbContext context)
        {
            _context = context;
        }

        public async Task<List<AssignmentType>> GetAssignmentTypesAsync()
        {
            return await _context.AssignmentTypes.ToListAsync();
        }

        public async Task<AssignmentType> GetAssignmentTypeAsync(int id)
        {
            return await _context.AssignmentTypes.FindAsync(id);
        }

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
    }
}
