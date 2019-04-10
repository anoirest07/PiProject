using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManage.Models
{
    public enum Gender
    { Male, Female };
    public enum Role
    {Participant, President };
    public enum City
    { Ariana, Béja, BenArous, Bizerte, Gabès, Gafsa, Jendouba, Kairouan, Kasserine, Kébili, Kef, Mahdia, Manouba, Médenine, Monastir, Nabeul, Sfax, SidiBouzid, Siliana, Sousse, Tataouine, Tozeur, Tunis, Zaghouan };
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Email { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password*")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [StringLength(8,MinimumLength =8)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number*")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Gender")]
        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }
        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]

        public DateTime BirthDate { get; set; }
        [Display(Name = "City*")]
        [EnumDataType(typeof(City))]
        public string City { get; set; }
        [Display(Name = "Home Address*")]

        public string HomeAddress { get; set; }


        public Boolean Enabled { get; set; }
        
        [Display(Name = "Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You have to accept the Terms and Conditions!")]
        public bool TermsAndConditions { get; set; }
        [Required]
        [Display(Name = "Role*")]
        [EnumDataType(typeof(Role), ErrorMessage = "You have to select a role!")]
        public string Role { get; set; }



        
        public string Image { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    
}
