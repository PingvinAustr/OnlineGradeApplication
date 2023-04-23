using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentsGroupRepository
    {
        List<StudentsGroup> GetStudentsGroupsAsync();
        StudentsGroup GetStudentsGroupAsync(int id);
        /*
        Task<StudentsGroup> AddStudentsGroupAsync(StudentsGroup studentsGroup);
        Task<StudentsGroup> UpdateStudentsGroupAsync(StudentsGroup studentsGroup);
        Task DeleteStudentsGroupAsync(int id);
        */
    }
}
