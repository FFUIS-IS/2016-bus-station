using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using Autobuska_stanica.Models;
using System.Security.Cryptography;
using System.Data;


namespace Autobuska_stanica.Repos
{
    class UserRepository
    {

        private static SqlCeConnection connection = DbConnection.Instance.Connection;

        public static bool Login(User user)
        {
            string sql = "SELECT [username],[password] FROM [LoginFormTable] WHERE [username] ='" + user.Username + "' AND [password] ='" + user.Password + "'";
            SqlCeCommand command = new SqlCeCommand(sql, connection);
            SqlCeDataAdapter da = new SqlCeDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (user.Username.Length == 0)
                throw new Exception("Username must be entered!");
            if (user.Password.Length == 0)
                throw new Exception("Password must be entered!");
            if (dt.Rows.Count == 0)
                throw new Exception("Invalid Login please check username and password");


            command.Prepare();
            SqlCeDataReader reader = command.ExecuteReader();

            return reader.Read();

        }

        public static void Register(User user)
        {
            string sql = "INSERT INTO LoginFormTable(username, password) VALUES ('" + user.Username + "', '" + hashPassword(user.Password) + "')";
            SqlCeCommand command = new SqlCeCommand(sql, connection);
            command.ExecuteReader();
        }

        private static string hashPassword(string password)
        {
            SHA256Managed sha256 = new SHA256Managed();

            byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(passwordInBytes);

            return Convert.ToBase64String(hash);
        }
    }
}
