using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_BLL.Responses
{
    public class GetTeachersByStudentId
    {
        public int? teacherId { get; set; }
        public PersonDTO teacher { get; set; }
        public DisciplineDTO discipline { get; set; }
    }
}
