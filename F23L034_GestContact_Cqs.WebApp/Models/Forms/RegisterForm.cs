using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace F23L034_GestContact_Cqs.WebApp.Models.Forms
{
#nullable disable
    public class RegisterForm
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Nom :")]
        public string Nom { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Prenom :")]
        public string Prenom { get; set; }
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
        [Compare(nameof(Passwd))]
        [DisplayName("Confirmation :")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}
