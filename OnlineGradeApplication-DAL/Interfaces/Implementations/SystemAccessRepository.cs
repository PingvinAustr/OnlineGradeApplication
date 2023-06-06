using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class SystemAccessRepository : ISystemAccessRepository
    {

        public List<SystemAccess> GetSystemAccessesAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.SystemAccesses.ToList();
        }
        public SystemAccess GetSystemAccessAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var systemAccess = _context.SystemAccesses.FirstOrDefault(x => x.Id == id);
            return systemAccess;
        }

        public List<GetSystemUsers> GetResponseSystemAccesses()
        {
            var _context = new OnlineGradesDbContext();
            List<GetSystemUsers> systemUsers = new List<GetSystemUsers>();

            foreach (var person in _context.SystemAccesses.ToList())
            {
                Console.WriteLine(person.Username);
                GetSystemUsers sysUser = new GetSystemUsers()
                {
                    SystemAccess = person
                };
                if (_context.Persons.Any(x => x.SystemAccessId == person.Id))
                {
                    sysUser.Id = _context.Persons.Where(x => x.SystemAccessId == person.Id)?.First()?.Id;
                    sysUser.FirstName = _context.Persons.Where(x => x.SystemAccessId == person.Id)?.First()?.FirstName;
                        sysUser.LastName = _context.Persons.Where(x => x.SystemAccessId == person.Id)?.First()?.LastName;
                        sysUser.Role = _context.Roles.Where(x => x.RoleId == _context.Persons.Where(x => x.SystemAccessId == person.Id).First().RoleId)?.First();
                }
                    systemUsers.Add(sysUser);
            }
            return systemUsers;

        }

        public void AddSystemAccess(string username, string password)
        {
            var _context = new OnlineGradesDbContext();
            _context.SystemAccesses.Add(new SystemAccess { Username = username, UserPassword = password });
            _context.SaveChanges();

        }
        

        public void DeleteSystemAccess(int id)
        {
            var _context = new OnlineGradesDbContext();
            try
            {
                var entryToDelete = _context.SystemAccesses.FirstOrDefault(x => x.Id == id);
                if (entryToDelete != null)
                {
                    _context.SystemAccesses.Remove(entryToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void EditSystemAccess(int id, string username, string password)
        {
            var _context = new OnlineGradesDbContext();
            try
            {
                _context.SystemAccesses.Where(x => x.Id == id).FirstOrDefault().UserPassword = password;
                _context.SystemAccesses.Where(x => x.Id == id).FirstOrDefault().Username = username;
                _context.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
