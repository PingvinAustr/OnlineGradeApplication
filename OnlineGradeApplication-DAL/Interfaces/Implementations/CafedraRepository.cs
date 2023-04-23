using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class CafedraRepository : ICafedraRepository
    {
        public List<Cafedra> GetCafedrasAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.Cafedras.ToList();
        }
        public Cafedra GetCafedraAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var cafedra = _context.Cafedras.FirstOrDefault(x => x.CafedraId == id);
            return cafedra;
        }
    }
}
