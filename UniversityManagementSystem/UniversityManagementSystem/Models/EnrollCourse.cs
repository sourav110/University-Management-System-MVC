using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class EnrollCourse
    {
        [Key]
        public int EnrollCourseId { get; set; }

        [Display(Name = "Student Reg No")]
        [Required(ErrorMessage = "Please Select Student Reg No.")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [NotMapped]
        public string Email { get; set; }

        [NotMapped]
        public string Department { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please Select a Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public DateTime Date { get; set; }

        public virtual string GradeLetter { set; get; }
        public bool IsEnroll { get; set; }
    }
}