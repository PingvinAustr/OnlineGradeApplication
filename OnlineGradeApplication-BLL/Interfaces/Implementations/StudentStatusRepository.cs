using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class StudentStatusRepository : IStudentStatusRepository
    {
        private readonly IMapper _IStudentStatusMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentStatusRepository _studentStatus;

        public StudentStatusRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IStudentStatusRepository studentStatus)
        {
            _studentStatus = studentStatus;
            _IStudentStatusMapper = mapper;
        }

        public List<StudentStatusDTO> GetStudentStatusesAsync()
        {
            List<StudentStatus> studentStatusFromDB = _studentStatus.GetStudentStatusesAsync();
            List<StudentStatusDTO> studentStatus = _IStudentStatusMapper.Map<List<StudentStatus>, List<StudentStatusDTO>>(studentStatusFromDB);
            return studentStatus;
        }
        public StudentStatusDTO GetStudentStatusAsync(int id)
        {
            var data = _studentStatus.GetStudentStatusAsync(id);
            StudentStatusDTO studentStatus = _IStudentStatusMapper.Map<StudentStatus, StudentStatusDTO>(data);
            return studentStatus;
        }
    }
}
