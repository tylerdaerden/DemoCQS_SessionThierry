namespace F23L034_GestContact_Cqs.WebApp.Infrastructure
{
#nullable disable
    public class UserInfo
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string NomComplet { get { return $"{Nom} {Prenom}"; } }
    }
}
