using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Responses;
using System.Text;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class DisciplineRepository : IDisciplineRepository
    {

        public List<Discipline> GetDisciplinesAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.Disciplines.ToList();
        }
        public Discipline GetDisciplineAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var discipline = _context.Disciplines.FirstOrDefault(x => x.Id == id);
            return discipline;
        }
        public List<StudentDisciplinesResponse> GetDisciplinesForUser(int userId)
        {
            var _context = new OnlineGradesDbContext();
            int? userRoleId = _context.Persons.Where(x=>x.Id == userId).FirstOrDefault().RoleId;
            List<StudentDisciplinesResponse> studentsDisciplinesResponse = new List<StudentDisciplinesResponse>();

            if (userRoleId == 1003)
            {

                int? userGroupId = _context.StudentsGroups.Where(x => x.StudentId == userId)?.FirstOrDefault()?.GroupId;

                List<TeachersGroup> disciplinesIdsOfCurrentUser = _context.TeachersGroups.Where(x => x.GroupId == userGroupId).ToList();

                var disciplinesOfUser = disciplinesIdsOfCurrentUser.Join(_context.Disciplines,
                    p => p.DisciplineId,
                    s => s.Id,
                    (p, s) => new Discipline() { Id = s.Id, DisciplineName = s.DisciplineName }).ToList();


               
                foreach (var discipline in disciplinesOfUser)
                {
                    StudentDisciplinesResponse studentResponseItem = new StudentDisciplinesResponse();
                    studentResponseItem.Student = _context.Persons.Where(x => x.Id == userId).FirstOrDefault();
                    studentResponseItem.Group = _context.Groups.Where(x => x.GroupId == userGroupId).FirstOrDefault();

                    int? teacherId = _context.TeachersGroups.Where(x => x.DisciplineId == discipline.Id && x.GroupId == userGroupId).FirstOrDefault().TeacherId;
                    studentResponseItem.Teacher = _context.Persons.Where(x => x.Id == teacherId).FirstOrDefault();

                    studentResponseItem.Discipline = _context.Disciplines.Where(x => x.Id == discipline.Id).FirstOrDefault();

                    studentResponseItem.TeacherGroupDbId = _context.TeachersGroups.Where(x => x.GroupId == studentResponseItem.Group.GroupId && x.TeacherId == studentResponseItem.Teacher.Id && x.DisciplineId == studentResponseItem.Discipline.Id).FirstOrDefault().Id;


                    Console.WriteLine(studentResponseItem.Teacher.FirstName);

                    studentsDisciplinesResponse.Add(studentResponseItem);
                }
            }
            else if (userRoleId == 1002)
            {
                List<TeachersGroup> disciplinesIdsOfCurrentUser = _context.TeachersGroups.Where(x => x.TeacherId == userId).ToList();

                var disciplinesOfUser = disciplinesIdsOfCurrentUser.Join(_context.Disciplines,
                    p => p.DisciplineId,
                    s => s.Id,
                    (p, s) => new Discipline() { Id = s.Id, DisciplineName = s.DisciplineName }).ToList();

                foreach (var discipline in disciplinesOfUser)
                {
                    StudentDisciplinesResponse studentResponseItem = new StudentDisciplinesResponse();

                    int? groupId = _context.TeachersGroups.Where(x => x.DisciplineId == discipline.Id && x.TeacherId == userId).FirstOrDefault().GroupId;
                    studentResponseItem.Group = _context.Groups.Where(x => x.GroupId == groupId).FirstOrDefault();

                    studentResponseItem.Teacher = _context.Persons.Where(x => x.Id == userId).FirstOrDefault();

                    studentResponseItem.Discipline = _context.Disciplines.Where(x => x.Id == discipline.Id).FirstOrDefault();

                    studentResponseItem.TeacherGroupDbId = _context.TeachersGroups.Where(x => x.GroupId == groupId && x.TeacherId == userId && x.DisciplineId == studentResponseItem.Discipline.Id).FirstOrDefault().Id;


                    studentsDisciplinesResponse.Add(studentResponseItem);
                }
            }
            else if (userRoleId == 1 || userRoleId == 2)
            {
                Console.WriteLine("Admin");
                foreach (var item in _context.TeachersGroups.ToList())
                {
                    StudentDisciplinesResponse studentDisciplinesResponse = new StudentDisciplinesResponse();
                    
                    studentDisciplinesResponse.Group = _context.Groups.Where(x=>x.GroupId == item.GroupId).FirstOrDefault();
                    studentDisciplinesResponse.Teacher = _context.Persons.Where(x=>x.Id == item.TeacherId).FirstOrDefault();
                    studentDisciplinesResponse.Discipline = _context.Disciplines.Where(x=>x.Id== item.DisciplineId).FirstOrDefault();
                    studentDisciplinesResponse.TeacherGroupDbId = _context.TeachersGroups.Where(x=>x.GroupId == item.GroupId && x.TeacherId == item.TeacherId && x.DisciplineId == item.DisciplineId).FirstOrDefault().Id;
                    studentsDisciplinesResponse.Add(studentDisciplinesResponse);
                }
            }


            return studentsDisciplinesResponse;
        }

        public bool DeleteGroupTeacherDisciplineEntry(int id)
        {
            var _context = new OnlineGradesDbContext();
            try
            {
                var entryToDelete = _context.TeachersGroups.FirstOrDefault(x => x.Id == id);
                if (entryToDelete != null)
                {
                    _context.TeachersGroups.Remove(entryToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditDisciplineInSchedule(int id, int teacherId, int groupId, int disciplineId)
        {
            try
            {
                var _context = new OnlineGradesDbContext();
                _context.TeachersGroups.Where(x => x.Id == id).FirstOrDefault().TeacherId = teacherId;
                _context.TeachersGroups.Where(x => x.Id == id).FirstOrDefault().GroupId = groupId;
                _context.TeachersGroups.Where(x => x.Id == id).FirstOrDefault().DisciplineId = disciplineId;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
