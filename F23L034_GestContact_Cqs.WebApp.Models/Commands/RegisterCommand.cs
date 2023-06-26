using Tools.Cqs.Commands;

namespace F23L034_GestContact_Cqs.WebApp.Models.Commands
{
    public class RegisterCommand : ICommand
    {
        public string Nom { get; init; }
        public string Prenom { get; init; }
        public string Email { get; init; }
        public string Passwd { get; init; }
        public RegisterCommand(string nom, string prenom, string email, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }
    }
}
