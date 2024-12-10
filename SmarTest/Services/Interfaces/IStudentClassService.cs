using MongoDB.Bson;
using SmarTest.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarTest.Services.Interfaces
{
    public interface IStudentClassService
    {
        Task<List<StudentClass>> GetAllStudentClassesAsync();
        Task AddStudentClassAsync(StudentClass studentClass);
        Task EditStudentClassAsync(StudentClass studentClass);
        Task DeleteStudentClassAsync(ObjectId id);
    }
}
