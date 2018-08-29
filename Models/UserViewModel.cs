using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public abstract class BaseEntity 
    {
         [Column("created_at")]
        public DateTime CreatedAt {get;set;}
        [Column("updated_at")]
        public DateTime UpdatedAt {get;set;}
    }
    public class RegisterUser : BaseEntity
    {
        [Key, Column("user_id")]
        public int UserId {get;set;}

        [Required(ErrorMessage="First Name is required")]
        [MinLength(2, ErrorMessage="A minimum of 2 is allowed for first name")]
        [MaxLength(30, ErrorMessage="A maximum of 30 is allowed for first name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Your first name must only contain letters")]
        [Display(Name="First Name")]
        [Column("first_name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Last name is required")]
        [MinLength(2, ErrorMessage="A minimum of 2 is allowed for last name")]
        [MaxLength(30, ErrorMessage="A maximum of 30 is allowed for last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Your last name must only contain letters")]
        [Display(Name="Last Name")]
        [Column("last_name")]
        public string LastName {get;set;}

        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string Email {get;set;}

        [Required(ErrorMessage="Password is required")]
        [MinLength(4, ErrorMessage="A minimum length of 4")]
        [MaxLength(20, ErrorMessage="A maximum length of 20")]
        [DataType(DataType.Password)]
        [Column("password")]
        public string Password {get;set;}

        [Required(ErrorMessage="Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get;set;}
    }

    public class LoginUser : BaseEntity
    {
        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage="This is an email field")]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        [Display(Name="Email")]
        public string LoginEmail {get;set;}

        [Required(ErrorMessage="Password is required")]
        [MinLength(4, ErrorMessage="A minimum length of 4")]
        [MaxLength(20, ErrorMessage="A maximum length of 20")]
        [DataType(DataType.Password)]
        [Column("password")]
        [Display(Name="Password")]

        public string LoginPassword {get;set;}
    }

    public class AddEventData : BaseEntity
    {
        public int HostId {get;set;}
        [Required(ErrorMessage="Wedder One is required")]
        [Column("wedder_one")]
        [MinLength(3, ErrorMessage="Min length of 3")]
        [MaxLength(40, ErrorMessage="Max length of 40")]
        [Display(Name="Wedder One")]
        public string WedderOne {get;set;}

        [Required(ErrorMessage="Wedder Two is required")]
        [Column("wedder_two")]
        [MinLength(3, ErrorMessage="Min length of 3")]
        [MaxLength(40, ErrorMessage="Max length of 40")]
        [Display(Name="Wedder Two")]
        public string WedderTwo {get;set;}

        [Required(ErrorMessage="Event Date is required")]
        [Column("event_date")]
        [Display(Name="Event Date")]
        [DataType(DataType.Date)]
        public DateTime EventDate {get;set;}

        [Required(ErrorMessage="Address is required")]
        [Column("address")]
        [MinLength(3, ErrorMessage="Min length of 3")]
        [MaxLength(40, ErrorMessage="Max length of 40")]
        [Display(Name="Address")]
        public string Address {get;set;}
        public Wedding TheWedding()
        {
            Wedding newWedding = new Wedding
            {
                HostId = this.HostId,
                WedderOne = this.WedderOne,
                WedderTwo = this.WedderTwo,
                EventDate = this.EventDate,
                Address = this.Address
            };
            return newWedding;
        }
    }

}