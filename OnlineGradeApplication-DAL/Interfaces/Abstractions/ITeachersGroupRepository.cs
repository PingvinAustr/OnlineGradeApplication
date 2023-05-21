using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface ITeachersGroupRepository
    {
        List<TeachersGroup> GetTeachersGroupsAsync();
        TeachersGroup GetTeachersGroupAsync(int id);
        void AddTeacherGroupEntry(TeachersGroup entry);
        /*
        Task<TeachersGroup> AddTeachersGroupAsync(TeachersGroup teachersGroup);
        Task<TeachersGroup> UpdateTeachersGroupAsync(TeachersGroup teachersGroup);
        Task DeleteTeachersGroupAsync(int id);
        */
    }
}
