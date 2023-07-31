using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Authentication_Authorization.Models
{
    public class Credential
    {
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
