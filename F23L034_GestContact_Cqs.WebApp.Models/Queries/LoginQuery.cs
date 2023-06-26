using F23L034_GestContact_Cqs.WebApp.Models.Entities;
using Tools.Cqs.Queries;

namespace F23L034_GestContact_Cqs.WebApp.Models.Queries
{
    public class LoginQuery : IQuery<Utilisateur?>
    {
        public string Email { get; init; }
        public string Passwd { get; init; }
        public LoginQuery(string email, string passwd)
        {
            Email = email;
            Passwd = passwd;
        }
    }
}
