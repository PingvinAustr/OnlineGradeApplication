using OnlineGradeApplication_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_DAL.Responses
{
    public class GetStudentsResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public Group? Group { get; set; }
    }
}
