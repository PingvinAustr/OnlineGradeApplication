using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class StudentCardRepository : IStudentCardRepository
    {
        private readonly IMapper _StudentCardMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentCardRepository _studentCard;

        public StudentCardRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentCardRepository studentCard)
        {
            _studentCard = studentCard;
            _StudentCardMapper = mapper;
        }

        public List<StudentCardDTO> GetStudentCardsAsync()
        {
            List<StudentCard> studentCardsFromDB = _studentCard.GetStudentCardsAsync();
            List<StudentCardDTO> studentCards = _StudentCardMapper.Map<List<StudentCard>, List<StudentCardDTO>>(studentCardsFromDB);
            return studentCards;
        }
        public StudentCardDTO GetStudentCardAsync(int id)
        {
            var data = _studentCard.GetStudentCardAsync(id);
            StudentCardDTO studentCard = _StudentCardMapper.Map<StudentCard, StudentCardDTO>(data);
            return studentCard;
        }
    }
}
