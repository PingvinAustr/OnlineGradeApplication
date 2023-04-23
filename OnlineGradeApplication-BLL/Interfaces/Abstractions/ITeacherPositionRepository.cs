using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface ITeacherPositionRepository
    {
        List<TeacherPositionDTO> GetTeacherPositionsAsync();
        TeacherPositionDTO GetTeacherPositionAsync(int id);
    }
}
