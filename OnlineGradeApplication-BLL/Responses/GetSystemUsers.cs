using OnlineGradeApplication_BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_BLL.Responses
{
    public class GetSystemUsers
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleDTO? Role { get; set; }
        public SystemAccessDTO? SystemAccess { get; set; }
    }
}
