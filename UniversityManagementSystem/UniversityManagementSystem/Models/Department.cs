using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Enter Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code Must be 2-7 Characters Long")]
        [Column(TypeName = "Varchar")]
        [Display(Name = "Code")]
        [Remote("IsCodeExists", "Departments", ErrorMessage = "Department Code Already Exists")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        [Display(Name = "Name")]
        [Remote("IsNameExists", "Departments", ErrorMessage = "Department Name Already Exists")]
        public string DepartmentName { get; set; }
    }
}