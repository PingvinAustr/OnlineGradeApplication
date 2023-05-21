using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class GroupRepository : IGroupRepository
    {

        public List<Group> GetGroupsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.Groups.ToList();
        }
        public Group GetGroupAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var group = _context.Groups.FirstOrDefault(x => x.GroupId == id);
            return group;
        }

        public List<GetGroups> GetGroupsInfo()
        {
            var _context = new OnlineGradesDbContext();
            List<GetGroups> _groups = new List<GetGroups>();
            foreach (var group in _context.Groups.ToList())
            {
                GetGroups _group = new GetGroups() { Id = group.GroupId, GroupName = group.GroupName, Year = group.GroupYear };
                _group.Cafedra = _context.Cafedras.Where(x => x.CafedraId == group.GroupCafedraId)?.FirstOrDefault();
                _groups.Add(_group);
            }
            return _groups;
        }
        public void AddGroup(Group group)
        {
            var _context = new OnlineGradesDbContext();
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public void EditGroup(int id, string name, int year, int cafedraId)
        {
            var _context = new OnlineGradesDbContext();
            _context.Groups.Where(x => x.GroupId == id).FirstOrDefault().GroupYear = year;
            _context.Groups.Where(x => x.GroupId == id).FirstOrDefault().GroupName = name;
            _context.Groups.Where(x => x.GroupId == id).FirstOrDefault().GroupCafedraId = cafedraId;
            _context.SaveChanges();
        }

        public void DeleteGroup(int id)
        {
            var _context = new OnlineGradesDbContext();
            try
            {
                var entryToDelete = _context.Groups.FirstOrDefault(x => x.GroupId == id);
                if (entryToDelete != null)
                {
                    _context.Groups.Remove(entryToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public int? GetGroupIdByPersonId(int personId)
        {
            var _context = new OnlineGradesDbContext();
            int? groupId = 0;
            foreach (var student in _context.StudentsGroups.ToList())
            {
                if (student.StudentId == personId)
                {
                    groupId = student.GroupId;
                }
            }
            return groupId;
        }
    }
}
