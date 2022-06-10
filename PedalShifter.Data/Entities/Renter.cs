using Microsoft.AspNetCore.Identity;
using PedalShifter.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedalShifter.Data.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateJoined { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string ProfilePicture { get; set; }
        public string GovernmentIssuedId { get; set; }
        public string IdentityId { get; set; }
    }
}
