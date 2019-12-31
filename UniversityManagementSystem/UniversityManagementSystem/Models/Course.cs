using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Enter Course Code")]
        [MinLength(5, ErrorMessage = "Code must be at least 5 character long")]
        [Display(Name = "Code")]
        [Column(TypeName = "varchar")]
        [Remote("IsCodeExists", "Courses", ErrorMessage = "Course Code Already Exists")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Please Enter Course Name")]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar")]
        [Remote("IsNameExists", "Courses", ErrorMessage = "Course Name Already Exists")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please Enter Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be in range between 0.5 to 5.0")]
        public double CourseCredit { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Semester")]
        [Required(ErrorMessage = "Please Select Semester")]
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        public virtual String AssignedTo { get; set; }

        public bool IsAssigned { get; set; }
        //public bool Status { get; set; }
    }
}