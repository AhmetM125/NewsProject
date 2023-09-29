using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace M_News.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Should be less than 30 characters")]
        public string Username { get; set; } = default!;
        [Required]
        [MaxLength(30, ErrorMessage = "Should be less than 30 characters")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Please complete the reCAPTCHA verification.")]
        [JsonProperty("g-recaptcha-response")]
        public string RecaptchaResponse { get; set; } = default!;


    }
}
