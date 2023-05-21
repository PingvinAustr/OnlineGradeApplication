using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IPersonRepository
    {
        List<PersonDTO> GetPeopleAsync();
        PersonDTO GetPersonAsync(int id);
        void AddStudent(PersonDTO person);
        void EditPerson(int id, string firstName, string lastName, int age, int role, int systemAccess);
        List<GetStudentsResponse> GetStudents();
        List<GetStudentsResponse> GetStudentByGroupId(int groupId);
    }
}
