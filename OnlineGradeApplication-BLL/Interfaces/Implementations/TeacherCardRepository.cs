using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class TeacherCardRepository : ITeacherCardRepository
    {
        private readonly IMapper _TeacherCardMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeacherCardRepository _teacherCard;

        public TeacherCardRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.ITeacherCardRepository teacherCard)
        {
            _teacherCard = teacherCard;
            _TeacherCardMapper = mapper;
        }

        public List<TeacherCardDTO> GetTeacherCardsAsync()
        {
            List<TeacherCard> teacherCardsFromDB = _teacherCard.GetTeacherCardsAsync();
            List<TeacherCardDTO> teacherCards = _TeacherCardMapper.Map<List<TeacherCard>, List<TeacherCardDTO>>(teacherCardsFromDB);
            return teacherCards;
        }
        public TeacherCardDTO GetTeacherCardAsync(int id)
        {
            var data = _teacherCard.GetTeacherCardAsync(id);
            TeacherCardDTO teacherCard = _TeacherCardMapper.Map<TeacherCard, TeacherCardDTO>(data);
            return teacherCard;
        }
    }
}
