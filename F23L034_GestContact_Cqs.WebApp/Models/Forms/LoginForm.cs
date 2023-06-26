using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace F23L034_GestContact_Cqs.WebApp.Models.Forms
{
#nullable disable
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        [StringLength(384)]
        [DisplayName("Email :")]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DisplayName("Mot de passe :")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
    }
}
