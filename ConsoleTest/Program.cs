using F23L034_GestContact_Cqs.WebApp.Models.Commands;
using F23L034_GestContact_Cqs.WebApp.Models.Entities;
using F23L034_GestContact_Cqs.WebApp.Models.Queries;
using F23L034_GestContact_Cqs.WebApp.Models.Repositories;
using F23L034_GestContact_Cqs.WebApp.Models.Services;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=F23L034_GestContact_Cqs;Integrated Security=True";

            //using (IDbConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            //{
            //    IAuthRepository authRepository = new AuthService(dbConnection);
            //    authRepository.Execute(new RegisterCommand("Desmecht", "Denys", "denis.desmecht@test.be", "Test1238="));
            //}

            using (IDbConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                IAuthRepository authRepository = new AuthService(dbConnection);
                Utilisateur? utilisateur = authRepository.Execute(new LoginQuery("thierry.morre@cognitic.be", "Test1234="));

                if (utilisateur is not null)
                    Console.WriteLine($"{utilisateur.Nom} {utilisateur.Prenom}");
            }
        }
    }
}