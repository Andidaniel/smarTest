using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarTest.DataLayer.Models
{
    public class StudentClass
    {
        public ObjectId _id { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Subclass is required")]
        public string Subclass { get; set; }

        [Required(ErrorMessage = "Class Teacher is required")]
        public string ClassTeacher { get; set; }
    }
}
