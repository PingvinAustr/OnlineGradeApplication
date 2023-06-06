using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class StudentAssignmentRepository : IStudentAssignmentRepository
    {

        public List<StudentAssignment> GetStudentAssignmentsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.StudentAssignments.ToList();
        }
        public StudentAssignment GetStudentAssignmentAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var studentAssignment = _context.StudentAssignments.FirstOrDefault(x => x.Id == id);
            return studentAssignment;
        }
        public List<StudentAssignmentResponse> GetStudentAssignmentsByStudentId(int studentId)
        {
            var _context = new OnlineGradesDbContext();
            List<StudentAssignmentResponse> studentAssignmentResponses = new List<StudentAssignmentResponse>();
            foreach (var item in _context.StudentAssignments.ToList())
            {
                if (item.StudentId == studentId)
                {
                    StudentAssignmentResponse studentAssignmentResponse = new StudentAssignmentResponse()
                    {
                        studentAssignmentId = item.Id,
                        studentAssignment = item,
                        Student = _context.Persons.Where(x => x.Id == studentId).FirstOrDefault(),
                        CreatedByTeacher = _context.Persons.Where(x => x.Id == item.CreatedByTeacherId).FirstOrDefault(),
                        ResponsibleTeacher = _context.Persons.Where(x => x.Id == item.ResponsibleTeacherId).FirstOrDefault(),
                        DueDate = item.DueDate,
                        CreatedOnDate = item.CreatedOnDate,
                        AssignmentType = _context.AssignmentTypes.Where(x=>x.Id == item.AssignmentTypeId).FirstOrDefault(),
                    };
                    studentAssignmentResponses.Add(studentAssignmentResponse);
                }
            }
            return studentAssignmentResponses;
        }

        public List<TeacherAssignmentResponse> GetTeacherAssignmentsByStudentId(int teacherId)
        {
            var _context = new OnlineGradesDbContext();
            List<TeacherAssignmentResponse> teacherAssignmentResponses = new List<TeacherAssignmentResponse>();
            foreach (var item in _context.StudentAssignments.ToList())
            {
                if (item.CreatedByTeacherId == teacherId || item.ResponsibleTeacherId == teacherId)
                {
                    TeacherAssignmentResponse teacherResponse = new TeacherAssignmentResponse()
                    {
                        studentAssignmentId = item.Id,
                        studentAssignment = item,
                        Student = _context.Persons.Where(x=>x.Id == item.StudentId).FirstOrDefault(),
                        CreatedByTeacher = _context.Persons.Where(x => x.Id == item.CreatedByTeacherId).FirstOrDefault(),
                        ResponsibleTeacher = _context.Persons.Where(x => x.Id == item.ResponsibleTeacherId).FirstOrDefault(),
                        DueDate = item.DueDate,
                        CreatedOnDate = item.CreatedOnDate,
                        AssignmentType = _context.AssignmentTypes.Where(x => x.Id == item.AssignmentTypeId).FirstOrDefault(),
                    };
                    int? studentGroupId = _context.StudentsGroups.Where(x=>x.StudentId == item.StudentId).FirstOrDefault().GroupId;
                    teacherResponse.StudentGroup = _context.Groups.Where(x=>x.GroupId == studentGroupId).FirstOrDefault();
                    teacherAssignmentResponses.Add(teacherResponse);
                }
            }
            return teacherAssignmentResponses;
        }
    }
}
