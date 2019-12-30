using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Day
    {
        [Key]
        public int DayId { get; set; }
        public string DayName { get; set; }
    }
}