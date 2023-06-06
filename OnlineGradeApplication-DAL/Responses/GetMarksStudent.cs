using OnlineGradeApplication_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_DAL.Responses
{
    public class GetMarksStudent
    {
        public int StudentMarkId { get; set; }
        public Person Student { get; set; }
        public Person Teacher { get; set; }
        public string AssignmentType { get; set; }
        public int? AssignmentId { get; set; }
        public int? Mark { get; set; }
        public int? Coefficient { get; set; }
    }
}
