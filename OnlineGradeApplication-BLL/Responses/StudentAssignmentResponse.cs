using OnlineGradeApplication_BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_BLL.Responses
{
    public class StudentAssignmentResponse
    {
        public int studentAssignmentId { get; set; }
        public StudentAssignmentDTO studentAssignment { get; set; }
        public PersonDTO Student { get; set; }
        public PersonDTO CreatedByTeacher { get; set; }
        public PersonDTO ResponsibleTeacher { get; set; }
        public AssignmentTypeDTO AssignmentType { get; set; }
        public DateOnly? CreatedOnDate { get; set; }
        public DateOnly? DueDate { get; set; }
    }
}
