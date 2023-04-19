using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface ICafedraRepository
    {
        Task<List<Cafedra>> GetCafedrasAsync();
        Task<Cafedra> GetCafedraAsync(int id);
        Task<Cafedra> AddCafedraAsync(Cafedra cafedra);
        Task<Cafedra> UpdateCafedraAsync(Cafedra cafedra);
        Task DeleteCafedraAsync(int id);
    }
}
