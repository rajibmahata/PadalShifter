using Microsoft.AspNetCore.Identity;
using PedalShifter.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedalShifter.Data.Entities
{
    public class HostOpenHour
    {
        [Key]
        public int Id { get; set; }
        public int HostId { get; set; }
        public Host Host { get; set; }
        public DateTime DateJoined { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; }


    }
}
