using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        [Key, Column("user_id")]
        public int UserId {get;set;}
        [Column("first_name")]
        public string FirstName {get;set;}
        [Column("last_name")]
        public string LastName {get;set;}
        [Column("email")]
        public string Email {get;set;}
        [Column("password")]
        public string Password {get;set;}

        public List<Wedding> Weddings {get;set;}
        public List<WeddingGuest> WeddingGuests {get;set;}
        public User()
        {
            Weddings = new List<Wedding>();
            WeddingGuests = new List<WeddingGuest>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }   
}