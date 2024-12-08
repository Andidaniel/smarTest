using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarTest.DataLayer.Models
{
    public class StudentClass
    {
        public ObjectId _id { get; set; }
        public int Number { get; set; }
        public string Subclass { get; set; }
        public string ClassTeacher { get; set; }
    }
}
