using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class TeacherPositionRepository : ITeacherPositionRepository
    {
        private readonly IMapper _TeacherPositionMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeacherPositionRepository _teacherPosition;

        public TeacherPositionRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeacherPositionRepository teacherPosition)
        {
            _teacherPosition = teacherPosition;
            _TeacherPositionMapper = mapper;
        }

        public List<TeacherPositionDTO> GetTeacherPositionsAsync()
        {
            List<TeacherPosition> teacherPositionsFromDB = _teacherPosition.GetTeacherPositionsAsync();
            List<TeacherPositionDTO> teacherPositions = _TeacherPositionMapper.Map<List<TeacherPosition>, List<TeacherPositionDTO>>(teacherPositionsFromDB);
            return teacherPositions;
        }
        public TeacherPositionDTO GetTeacherPositionAsync(int id)
        {
            var data = _teacherPosition.GetTeacherPositionAsync(id);
            TeacherPositionDTO teacherPosition = _TeacherPositionMapper.Map<TeacherPosition, TeacherPositionDTO>(data);
            return teacherPosition;
        }
    }
}
