using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SmarTest.DataLayer.Models
{
    public class User
    {
        public ObjectId _id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        public bool IsTeacher { get; set; }

        public ObjectId? StudentClassId { get; set; }
        public StudentClassWithoutId? StudentClass { get; set; }
    }
}
    