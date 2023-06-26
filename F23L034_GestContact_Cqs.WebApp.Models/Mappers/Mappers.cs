using F23L034_GestContact_Cqs.WebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F23L034_GestContact_Cqs.WebApp.Models.Mappers
{
    internal static class Mappers
    {
        public static Utilisateur ToUtilisateur(this IDataRecord record)
        {
            return new Utilisateur((int)record["Id"], (string)record["Nom"], (string)record["Prenom"], (string)record["Email"]);
        }
    }
}
