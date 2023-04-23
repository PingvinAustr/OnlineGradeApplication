using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class StudentMarkRepository : IStudentMarkRepository
    {
        private readonly IMapper _StudentMarkMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentMarkRepository _studentMark;

        public StudentMarkRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentMarkRepository studentMark)
        {
            _studentMark = studentMark;
            _StudentMarkMapper = mapper;
        }

        public List<StudentMarkDTO> GetStudentMarksAsync()
        {
            List<StudentMark> studentMarksFromDB = _studentMark.GetStudentMarksAsync();
            List<StudentMarkDTO> studentMarks = _StudentMarkMapper.Map<List<StudentMark>, List<StudentMarkDTO>>(studentMarksFromDB);
            return studentMarks;
        }
        public StudentMarkDTO GetStudentMarkAsync(int id)
        {
            var data = _studentMark.GetStudentMarkAsync(id);
            StudentMarkDTO studentMark = _StudentMarkMapper.Map<StudentMark, StudentMarkDTO>(data);
            return studentMark;
        }
    }
}
