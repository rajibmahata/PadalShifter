using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PedalShifter.Data.ViewModels
{
    public class HostViewModel
    {
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateJoined { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

        public double PreferredLocationLattitude { get; set; }
        public double PreferredLocationLongitude { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string FileName { get; set; }
        
    }
}
