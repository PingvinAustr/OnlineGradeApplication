using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IPersonRepository
    {
        List<PersonDTO> GetPeopleAsync();
        PersonDTO GetPersonAsync(int id);
    }
}
