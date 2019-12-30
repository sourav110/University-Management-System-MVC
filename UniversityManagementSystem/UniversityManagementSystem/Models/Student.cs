using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please Enter Student Name")]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]
        [Column(TypeName = "varchar")]
        [Remote("IsEmailExists", "Students", ErrorMessage = "Email Already Exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Contact No.")]
        [Display(Name = "Contact No.")]
        [Remote("IsContactNoExists", "Students", ErrorMessage = "Contact No. Already Exists")]
        public string ContactNo { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public string RegNo { get; set; }
    }
}