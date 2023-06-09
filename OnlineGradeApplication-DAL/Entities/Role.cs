﻿using System;
using System.Collections.Generic;

namespace OnlineGradeApplication_DAL.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
