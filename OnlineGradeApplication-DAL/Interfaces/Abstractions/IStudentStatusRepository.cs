﻿using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentStatusRepository
    {
        Task<List<StudentStatus>> GetStudentStatusesAsync();
        Task<StudentStatus> GetStudentStatusAsync(int id);
        Task<StudentStatus> AddStudentStatusAsync(StudentStatus studentStatus);
        Task<StudentStatus> UpdateStudentStatusAsync(StudentStatus studentStatus);
        Task DeleteStudentStatusAsync(int id);
    }
}
