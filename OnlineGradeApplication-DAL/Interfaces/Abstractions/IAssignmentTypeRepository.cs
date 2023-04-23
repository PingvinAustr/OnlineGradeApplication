using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IAssignmentTypeRepository
    {
        List<AssignmentType> GetAssignmentTypesAsync();
        AssignmentType GetAssignmentTypeAsync(int id);
        /*
        Task AddAssignmentTypeAsync(AssignmentType assignmentType);
        Task UpdateAssignmentTypeAsync(AssignmentType assignmentType);
        Task DeleteAssignmentTypeAsync(int id);
        */
    }
}
