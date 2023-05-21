using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineGradeApplication_DAL.Entities;
namespace OnlineGradeApplication_DAL.Responses
{
    public class GetSystemUsers
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role? Role { get; set; }
        public SystemAccess? SystemAccess { get; set; }
    }
}
