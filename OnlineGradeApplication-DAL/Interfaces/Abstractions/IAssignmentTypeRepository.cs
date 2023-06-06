using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IAssignmentTypeRepository
    {
        List<AssignmentType> GetAssignmentTypesAsync();
        AssignmentType GetAssignmentTypeAsync(int id);
    }
}
