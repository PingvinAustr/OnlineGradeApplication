using OnlineGradeApplication_BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_BLL.Responses
{
    public class GetMarksStudent
    {
        public int StudentMarkId { get; set; }
        public PersonDTO Student { get; set; }
        public PersonDTO Teacher { get; set; }
        public string AssignmentType { get; set; }
        public int? AssignmentId { get; set; }
        public int? Mark { get; set; }
        public int? Coefficient { get; set; }
    }
}
