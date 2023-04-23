using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IAssignmentTypeRepository
    {
        List<AssignmentTypeDTO> GetAssignmentTypesAsync();
        AssignmentTypeDTO GetAssignmentTypeAsync(int id);
    }
}
