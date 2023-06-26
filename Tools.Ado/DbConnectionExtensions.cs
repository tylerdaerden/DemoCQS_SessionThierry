using System.Data;
using System.Reflection;

namespace Tools.Ado
{
    public static class DbConnectionExtensions
    {
        public static int ExecuteNonQuery(this IDbConnection connection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            if (connection.State is not ConnectionState.Open)
                throw new InvalidOperationException("The connection must be open.");

            using (IDbCommand dbCommand = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                return dbCommand.ExecuteNonQuery();
            }
        }
        public static object? ExecuteScalar(this IDbConnection connection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            if (connection.State is not ConnectionState.Open)
                throw new InvalidOperationException("The connection must be open.");

            using (IDbCommand dbCommand = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                object? result = dbCommand.ExecuteScalar();
                return result is DBNull ? null : result;
            }
        }
        
        public static IEnumerable<TResult> ExecuteReader<TResult>(this IDbConnection connection, string query, Func<IDataRecord, TResult> selector, bool isStoredProcedure = false, object? parameters = null)
        {
            if (connection.State is not ConnectionState.Open)
                throw new InvalidOperationException("The connection must be open.");

            ArgumentNullException.ThrowIfNull(selector);

            using (IDbCommand dbCommand = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                using (IDataReader dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        yield return selector(dataReader);
                    }
                }
            }
        }

        private static IDbCommand CreateCommand(IDbConnection connection, string query, bool isStoredProcedure, object? parameters)
        {
            if (string.IsNullOrEmpty(query?.Trim()))
            {
                throw new ArgumentException(nameof(query));
            }

            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            if (isStoredProcedure)
                command.CommandType = CommandType.StoredProcedure;

            if (parameters is not null)
            {
                Type type = parameters.GetType();
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.CanRead)
                    {
                        IDataParameter parameter = command.CreateParameter();
                        parameter.ParameterName = property.Name;
                        parameter.Value = property.GetValue(parameters, null) ?? DBNull.Value;
                        command.Parameters.Add(parameter);
                    }
                }
            }

            return command;
        }
    }
}