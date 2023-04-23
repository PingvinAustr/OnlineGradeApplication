using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
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
    }
}
