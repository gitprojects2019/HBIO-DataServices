using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.DbModels;
using Services.Interface;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly ObjectContext _context = null;

        public StudentRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public Task Add(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await _context.Students.Find(x => true).ToListAsync();
        }

        public async Task<Student> Get(string id)
        {
            var student = Builders<Student>.Filter.Eq("Id", id);
            return await _context.Students.Find(student).FirstOrDefaultAsync();
        }

        public Task<DeleteResult> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteResult> Remove()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Update(string id, Student student)
        {
            await _context.Students.ReplaceOneAsync(zz => zz.Id == id, student);
            return "";
        }
    }
}
