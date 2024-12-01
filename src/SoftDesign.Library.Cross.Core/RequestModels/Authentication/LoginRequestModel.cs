using System.ComponentModel.DataAnnotations;

namespace SoftDesign.Library.Cross.Core.RequestModels.Authentication
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters.")]
        public string Password { get; set; }

        public LoginRequestModel()
        {
            
        }
        
        public LoginRequestModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}