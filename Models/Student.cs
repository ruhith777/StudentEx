using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEx.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public int RollNo { get; set; }
        public DateTime Dob { get; set; }
        public string City { get; set; }
    }
}
