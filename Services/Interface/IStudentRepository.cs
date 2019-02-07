using MongoDB.Driver;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAsync();
        Task<Student> Get(string id);
        Task Add(Student student);
        Task<String> Update(string id, Student student);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> Remove();

    }
}
