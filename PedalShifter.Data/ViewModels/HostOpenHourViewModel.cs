using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PedalShifter.Data.ViewModels
{
    public class HostOpenHourViewModel
    {
        public int Id { get; set; }
        public int HostId { get; set; }
        public DateTime DateJoined { get; set; }
        public string Day { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        public bool IsActive { get; set; }

    }
}
