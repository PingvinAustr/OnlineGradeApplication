using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface ICafedraRepository
    {
        List<Cafedra> GetCafedrasAsync();
        Cafedra GetCafedraAsync(int id);
        /*
        Task<Cafedra> AddCafedraAsync(Cafedra cafedra);
        Task<Cafedra> UpdateCafedraAsync(Cafedra cafedra);
        Task DeleteCafedraAsync(int id);
        */
    }
}
