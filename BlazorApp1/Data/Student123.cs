using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class Student123
    {
        [BsonId][BsonIgnoreIfDefault]
        public ObjectId id { get; set; }
        [BsonElement]
        public string name;
        [BsonElement]
        public string surname;
        [BsonElement]
        public int group;
        [BsonElement]
        public string faculty;
        public static List<string> titles=new List<string>() { "Имя","Фамилия","Факультет","Группа"};

        public Student123(string name, string surname, int group, string faculty)
        {
            this.name = name;
            this.surname = surname;
            this.group = group;
            this.faculty = faculty;
        }
        public static List<Student123> GetStudents()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("StudentBlazor(Napitok)");
            var collection = db.GetCollection<Student123>("StudetsCollection");
            return collection.Find(x => true).ToList();
        }
    }
}
