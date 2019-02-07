using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Services.Interface;
using Services.Models;

namespace BooksApi.Services
{
    public class BookService 
    {
        private readonly IMongoCollection<Student> _students;

        #region snippet_BookServiceConstructor
        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _students = database.GetCollection<Student>("Books");
        }
        #endregion

        public List<Student> Get()
        {
            return _students.Find(book => true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find<Student>(student => student.Id == id).FirstOrDefault();
        }

        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void Update(string id, Student studIn)
        {
            _students.ReplaceOne(book => book.Id == id, studIn);
        }

        public void Remove(Student studIn)
        {
            _students.DeleteOne(book => book.Id == studIn.Id);
        }

        public void Remove(string id)
        {
            _students.DeleteOne(book => book.Id == id);
        }
    }
}