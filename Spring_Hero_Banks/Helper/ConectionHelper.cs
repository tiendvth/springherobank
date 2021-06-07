﻿using MySql.Data.MySqlClient;

namespace Spring_Hero_Banks.helper
{
    public class ConnectionHelper
    {
        private const string Server = "127.0.0.1";
        private const string DbName = "springherobank";
        private const string UserName = "root";
        private const string Password = "";

        private static readonly string StringConnection =
            $"Server={Server};database={DbName};UID={UserName};password={Password}";

        private MySqlConnection _connectionBank = null;

        public MySqlConnection Connection()
        {
            if (_connectionBank == null)
            {
                _connectionBank = new MySqlConnection(StringConnection);
                // Console.WriteLine("Đã tạo kết nối mới");
                _connectionBank.Open();
                return _connectionBank;
            }
            else
            {
                return _connectionBank;
            }
        }
    }
}