using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AllocatedClassroom
    {
        [Key]
        public int AllocatedClassroomId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Display(Name = "Room")]
        [Required(ErrorMessage = "Please select Room")]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [Display(Name = "Day")]
        [Required(ErrorMessage = "Please select Day")]
        public int DayId { get; set; }
        [ForeignKey("DayId")]
        public virtual Day Day { get; set; }

        [Display(Name = "From")]
        //[Column(TypeName ="time")]
        //[DataType(DataType.Time)]
        public string FromTime { get; set; }

        [Display(Name = "To")]
        //[Column(TypeName="time")]
        //[DataType(DataType.Time)]
        public string ToTime { get; set; }

        public bool AllocationStatus { get; set; }
    }
}