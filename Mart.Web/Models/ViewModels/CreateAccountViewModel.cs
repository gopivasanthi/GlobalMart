using System.ComponentModel.DataAnnotations;

namespace Mart.Web.Models.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required(ErrorMessage = "Email Id is Mandatory to create an account")]
        public string EmailId { get; set; } = string.Empty;
        [Required(ErrorMessage = "Confirm Email Id should match with the previous email id field")]
        public string ConfirmEmailId { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password supplied is not according to the policy. It should have atleast one capital letter, one small letter and one number with minimum 6 characters")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Confirm Password not matching with the previous password field")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required(ErrorMessage = "Give us your first name for displaying")]
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
    }
}
