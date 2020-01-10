using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [MetadataType(typeof(EmployeeAnnotition))]
    public partial class Employee
    {
    }
    public class EmployeeAnnotition
    {
        [DisplayName("Name")]
        [Required]
        public string Name { set; get; }
        [Required]
        public int Age { set; get; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string JopTitle { get; set; }
        public Boolean IsActive { get; set; }
    }
    }