using System.Collections.Generic;
using MongoDB.Driver;
namespace BlazorApp1.Data
{
    public class StudentExtansion
    {
        public static List<Student123> list = Student123.GetStudents();
        public static List<string> titles = Student123.titles;

        public async static void Add(Student123 student)
        {
            list.Add(student);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("StudentBlazor");
            var collection = db.GetCollection<Student123>("StudentBlazorCollection");
            await collection.InsertOneAsync(student);

        }
    }
}
