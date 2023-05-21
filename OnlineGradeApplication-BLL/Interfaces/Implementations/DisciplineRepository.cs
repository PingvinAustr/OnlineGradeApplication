using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Responses;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly IMapper _DisciplineMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IDisciplineRepository _discipline;

        public DisciplineRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IDisciplineRepository discipline)
        {
            _discipline = discipline;
            _DisciplineMapper = mapper;
        }

        public List<DisciplineDTO> GetDisciplinesAsync()
        {
            List<Discipline> disciplinesFromDB = _discipline.GetDisciplinesAsync();
            List<DisciplineDTO> disciplines = _DisciplineMapper.Map<List<Discipline>, List<DisciplineDTO>>(disciplinesFromDB);
            return disciplines;
        }
        public DisciplineDTO GetDisciplineAsync(int id)
        {
            var data = _discipline.GetDisciplineAsync(id);
            DisciplineDTO discipline = _DisciplineMapper.Map<Discipline, DisciplineDTO>(data);
            return discipline;
        }

        public List<StudentDisciplinesResponse> GetDisciplinesForUser(int userId)
        {
            var data = _discipline.GetDisciplinesForUser(userId);
            List<StudentDisciplinesResponse> disciplines = _DisciplineMapper.Map<List<OnlineGradeApplication_DAL.Responses.StudentDisciplinesResponse>, List<OnlineGradeApplication_BLL.Responses.StudentDisciplinesResponse>>(data);
            return disciplines;
        }

        public bool DeleteGroupTeacherDisciplineEntry(int id)
        {
            var data = _discipline.DeleteGroupTeacherDisciplineEntry(id);
            return data;
        }

        public bool EditDisciplineInSchedule(int id, int teacherId, int groupId, int disciplineId)
        {
            var data=_discipline.EditDisciplineInSchedule(id, teacherId, groupId, disciplineId);
            return data;
        }
    }
}
