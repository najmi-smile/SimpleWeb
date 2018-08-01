using System.Collections.Generic;
using System.Data.SqlClient;
using SimpleWeb.Interfaces;
using System.Configuration;
using SimpleWeb.Entities;
using System.Text;
using System;
using System.Data;

namespace SimpleWeb.Services
{
    public class UserService : IUserService
    {

        protected IConnectionFactory ConnectionFactory { get; private set; }
        protected string ConnectionString { get; private set; }

        
        // In case of connection string rovided then use the default connection factory
        public UserService(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.ConnectionFactory = new Helpers.SqlConnectionFactory();
        }

        public List<UserDto> GetAllUsers()
        {
            List<UserDto> usersList = new List<UserDto>();

            using (IDbConnection connection = ConnectionFactory.GetConnection(this.ConnectionString))
            {
                connection.Open();
                StringBuilder query = new StringBuilder();
                query.AppendLine($"SELECT [Id],[UserName],[Email],[Password] FROM [SimpleBlog].[dbo].[Users]");

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query.ToString();
                    command.Connection = connection;

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usersList.Add(new UserDto()
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString()
                            });
                        }
                    }
                }
            }
            return usersList;
        }
    }
}
