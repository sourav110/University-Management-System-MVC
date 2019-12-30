using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
    }
}