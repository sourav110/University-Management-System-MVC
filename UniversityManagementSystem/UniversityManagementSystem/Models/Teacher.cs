using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please Enter Teacher Name")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string TeacherName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]
        [Column(TypeName = "varchar")]
        //[DataType(DataType.EmailAddress)]
        [Remote("IsEmailExists", "Teachers", ErrorMessage = "Email already exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Contact No.")]
        [Display(Name = "Contact No.")]
        [Remote("IsContactNoExists", "Teachers", ErrorMessage = "Contact NO. already exists")]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Please Select Designation")]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Credit to be taken")]
        [Required(ErrorMessage = "Please Enter Credit to be taken by Teacher")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Credit must be Non-Negative")]
        public double CreditToBeTaken { get; set; }

        public double RemainingCredit { get; set; }
    }
}