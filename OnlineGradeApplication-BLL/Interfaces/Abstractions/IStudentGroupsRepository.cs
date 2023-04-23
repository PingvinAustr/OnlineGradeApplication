using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IStudentGroupsRepository
    {
        List<StudentsGroupDTO> GetStudentsGroupsAsync();
        StudentsGroupDTO GetStudentsGroupAsync(int id);
    }
}
