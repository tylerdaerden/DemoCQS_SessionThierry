using F23L034_GestContact_Cqs.WebApp.Models.Repositories;
using System.Data;
using Tools.Cqs.Commands;
using Tools.Ado;
using F23L034_GestContact_Cqs.WebApp.Models.Entities;
using F23L034_GestContact_Cqs.WebApp.Models.Mappers;
using F23L034_GestContact_Cqs.WebApp.Models.Queries;
using F23L034_GestContact_Cqs.WebApp.Models.Commands;

namespace F23L034_GestContact_Cqs.WebApp.Models.Services
{
    public class AuthService : IAuthRepository
    {
        public IDbConnection _dbConnection;

        public AuthService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        #region Queries Implementation
        public Utilisateur? Execute(LoginQuery query)
        {
            _dbConnection.Open();
            Utilisateur? utilisateur = _dbConnection.ExecuteReader("CSP_Login", dr => dr.ToUtilisateur(), true, query).SingleOrDefault();
            _dbConnection.Close();
            return utilisateur;
        }

        #endregion

        #region Commands Implementation

        public Result Execute(RegisterCommand command)
        {            
            try
            {
                _dbConnection.Open();
                //Appeler la procédure CSP_Register
                _dbConnection.ExecuteNonQuery("CSP_Register", true, command);
                _dbConnection.Close();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
        #endregion
    }
}
