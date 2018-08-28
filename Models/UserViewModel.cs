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
        public string LoginEmail {get;set;}

        [Required(ErrorMessage="Password is required")]
        [MinLength(4, ErrorMessage="A minimum length of 4")]
        [MaxLength(20, ErrorMessage="A maximum length of 20")]
        [DataType(DataType.Password)]
        [Column("password")]

        public string LoginPassword {get;set;}
    }

}