using MongoDB.Bson;
using MongoDB.Driver;
using SmarTest.DataLayer;
using SmarTest.DataLayer.Models;
using SmarTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarTest.Services
{
    public class StudentClassService : BaseService<StudentClass>, IStudentClassService
    {
        public StudentClassService(SmarTestDbContext dbContext) : base(dbContext) { }

        public async Task<List<StudentClass>> GetAllStudentClassesAsync()
        {
            var result = await GetAllAsync();
            return result.ToList();
        }

        public async Task AddStudentClassAsync(StudentClass studentClass)
        {
            if (studentClass == null)
                throw new ArgumentNullException(nameof(studentClass));

            await AddAsync(studentClass);
        }

        public async Task EditStudentClassAsync(StudentClass studentClass)
        {
            if (studentClass == null)
                throw new ArgumentNullException(nameof(studentClass));

            var existingStudentClass = await GetByIdAsync(studentClass._id);
            if (existingStudentClass != null)
            {
                existingStudentClass.Number = studentClass.Number;
                existingStudentClass.Subclass = studentClass.Subclass;
                existingStudentClass.ClassTeacher = studentClass.ClassTeacher;

                await UpdateAsync(existingStudentClass);
            }
        }

        public async Task DeleteStudentClassAsync(ObjectId id)
        {
            await DeleteAsync(id);
        }
    }
}
