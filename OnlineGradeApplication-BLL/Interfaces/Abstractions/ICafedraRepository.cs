using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface ICafedraRepository
    {
        List<CafedraDTO> GetCafedrasAsync();
        CafedraDTO GetCafedraAsync(int id);
    }
}
