using OnlineGradeApplication_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGradeApplication_DAL.Responses
{
    public class GetGroups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int? Year { get; set; }
        public Cafedra Cafedra { get; set; }
    }
}
