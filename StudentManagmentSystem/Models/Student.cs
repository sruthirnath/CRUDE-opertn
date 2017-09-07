using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagmentSystem.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Remote("validation","Student",ErrorMessage ="user name already exists")]
        public String Name { get; set; }
        public int Age { get; set; }
    }
}