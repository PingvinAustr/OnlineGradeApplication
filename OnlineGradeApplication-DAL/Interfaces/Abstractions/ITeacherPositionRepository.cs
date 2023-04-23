using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface ITeacherPositionRepository
    {
        List<TeacherPosition> GetTeacherPositionsAsync();
        TeacherPosition GetTeacherPositionAsync(int id);
        /*
        Task<TeacherPosition> AddTeacherPositionAsync(TeacherPosition teacherPosition);
        Task<TeacherPosition> UpdateTeacherPositionAsync(TeacherPosition teacherPosition);
        Task DeleteTeacherPositionAsync(int id);
        */
    }
}
