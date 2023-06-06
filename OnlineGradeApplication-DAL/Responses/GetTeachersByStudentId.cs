using OnlineGradeApplication_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_DAL.Responses
{
    public class GetTeachersByStudentId
    {
        public int? teacherId { get; set; }
        public Person teacher { get; set; }
        public Discipline discipline { get; set; }
    }
}
