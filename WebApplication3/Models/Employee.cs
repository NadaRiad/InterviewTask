using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public int Age { set; get; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public string JopTitle { get; set; }
        public Boolean IsActive { get; set; }
    }
}