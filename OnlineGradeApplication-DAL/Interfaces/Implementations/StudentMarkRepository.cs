using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class StudentMarkRepository : IStudentMarkRepository
    {

        public List<StudentMark> GetStudentMarksAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.StudentMarks.ToList();
        }
        public StudentMark GetStudentMarkAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var studentMark = _context.StudentMarks.FirstOrDefault(x => x.Id == id);
            return studentMark;
        }

        public List<GetMarksStudent> GetStudentMarksByStudentId(int studentId)
        {
            var _context = new OnlineGradesDbContext();
            List<GetMarksStudent> getMarksStudents = new List<GetMarksStudent>();
            foreach (var item in _context.StudentMarks.ToList())
            {
                if (item.StudentId == studentId)
                {
                    var studentMark = new GetMarksStudent()
                    {
                        StudentMarkId = item.Id,
                        Student = _context.Persons.Where(x => x.Id == studentId).FirstOrDefault(),
                        Mark = item.AssignmentMark,
                        AssignmentId = item.AssignmentId
                    };
                    int? teacherId = _context.StudentAssignments.Where(x=>x.Id == item.AssignmentId).FirstOrDefault().ResponsibleTeacherId;
                    studentMark.Teacher = _context.Persons.Where(x=>x.Id == teacherId).FirstOrDefault();
                    int? assignmentTypeId = _context.StudentAssignments.Where(x => x.Id == item.AssignmentId).FirstOrDefault().AssignmentTypeId;
                    studentMark.AssignmentType = _context.AssignmentTypes.Where(x=>x.Id==assignmentTypeId).FirstOrDefault().AssignmentName;
                    studentMark.Coefficient = _context.AssignmentTypes.Where(x => x.Id == assignmentTypeId).FirstOrDefault().AssignmentWeightPercent;
                    getMarksStudents.Add(studentMark);
                }
            }
            return getMarksStudents;
        }

        public List<GetMarksStudent> GetMarksByTeacherId(int teacherId)
        {
            var _context = new OnlineGradesDbContext();
            List<GetMarksStudent> getMarksStudent = new List<GetMarksStudent>();
            foreach (var item in _context.StudentMarks.ToList())
            {
                int? createdByTeacherId = _context.StudentAssignments.Where(x => x.Id == item.AssignmentId).FirstOrDefault().CreatedByTeacherId;
                int? responsibleTeacherId = _context.StudentAssignments.Where(x => x.Id == item.AssignmentId).FirstOrDefault().ResponsibleTeacherId;
                if (teacherId == createdByTeacherId || teacherId == responsibleTeacherId)
                {
                    var studentMark = new GetMarksStudent()
                    {
                        StudentMarkId = item.Id,
                        Teacher = _context.Persons.Where(x=>x.Id == teacherId).FirstOrDefault(),
                        Mark = item.AssignmentMark,
                        AssignmentId = item.AssignmentId,
                        Student = _context.Persons.Where(x=>x.Id == item.StudentId).FirstOrDefault(),
                    };
                    int? assignmentTypeId = _context.StudentAssignments.Where(x => x.Id == item.AssignmentId).FirstOrDefault().AssignmentTypeId;
                    studentMark.AssignmentType = _context.AssignmentTypes.Where(x => x.Id == assignmentTypeId).FirstOrDefault().AssignmentName;
                    studentMark.Coefficient = _context.AssignmentTypes.Where(x => x.Id == assignmentTypeId).FirstOrDefault().AssignmentWeightPercent;
                    getMarksStudent.Add(studentMark);
                } 
            }
            return getMarksStudent;
        }
    }
}
