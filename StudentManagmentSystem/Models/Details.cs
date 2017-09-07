using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagmentSystem.Models
{
    public class DetailsContext: DbContext
    {
        public DetailsContext() : base("DefaultConnection")
        {

        }
        public DbSet<Student> Students { get; set; }
        

    }
}