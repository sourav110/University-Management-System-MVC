using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class AssignCourse
    {
        [Key]
        public int AssignCourseId { set; get; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { set; get; }
        public virtual Teacher Teacher { get; set; }

        [DefaultValue(0.0)]
        public virtual double CreditToBeTaken { set; get; }

        [DefaultValue(0.0)]
        public virtual double RemainingCredit { set; get; }

        [Display(Name = "Course Code")]
        //[Remote("IsAssigned", "AssignCourses", ErrorMessage = "This Course Already been Assigned")]
        public int CourseId { set; get; }
        public virtual Course Course { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string CourseName { get; set; }

        [NotMapped]
        [Display(Name ="Credit")]
        public double CourseCredit { get; set; }
    }
}