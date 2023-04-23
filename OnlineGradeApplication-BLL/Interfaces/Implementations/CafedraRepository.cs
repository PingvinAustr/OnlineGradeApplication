using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class CafedraRepository : ICafedraRepository
    {
        private readonly IMapper _CafedraMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.ICafedraRepository _cafedra;

        public CafedraRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.ICafedraRepository cafedra)
        {
            _cafedra = cafedra;
            _CafedraMapper = mapper;
        }

        public List<CafedraDTO> GetCafedrasAsync()
        {
            List<Cafedra> cafedrasFromDB = _cafedra.GetCafedrasAsync();
            List<CafedraDTO> cafedras = _CafedraMapper.Map<List<Cafedra>, List<CafedraDTO>>(cafedrasFromDB);
            return cafedras;
        }
        public CafedraDTO GetCafedraAsync(int id)
        {
            var data = _cafedra.GetCafedraAsync(id);
            CafedraDTO cafedra = _CafedraMapper.Map<Cafedra, CafedraDTO>(data);
            return cafedra;
        }
    }
}
