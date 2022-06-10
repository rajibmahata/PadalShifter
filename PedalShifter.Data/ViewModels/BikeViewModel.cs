using Microsoft.AspNetCore.Http;
using PedalShifter.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedalShifter.Data.ViewModels
{
    public class BikeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal DailyRate { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Required]
        public string Category { get; set;}

        [Required(ErrorMessage = "Please add an image of your bike.")]
        [Display(Name = "Main Image")]
        public IFormFile MainImage { get; set; }
        public string FileName { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public double PreferredLocationLattitude { get; set; }
        public double PreferredLocationLongitude { get; set; }
        public Host Host { get; set; }
        public IEnumerable<HostOpenHour> HostOpenHours { get; set; }
    }
}
