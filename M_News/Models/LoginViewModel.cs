using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace M_News.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Please complete the reCAPTCHA verification.")]
        [JsonProperty("g-recaptcha-response")]
        public string RecaptchaResponse { get; set; }


    }
}
