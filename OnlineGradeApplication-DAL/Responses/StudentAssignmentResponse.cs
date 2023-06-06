using OnlineGradeApplication_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_DAL.Responses
{
    public class StudentAssignmentResponse
    {
        public int studentAssignmentId { get; set; }
        public StudentAssignment studentAssignment { get; set; }
        public Person Student { get; set; }
        public Person CreatedByTeacher { get; set; }
        public Person ResponsibleTeacher { get; set; }
        public AssignmentType AssignmentType { get; set; }
        public DateOnly? CreatedOnDate { get; set; }
        public DateOnly? DueDate { get; set; }
    }
}
