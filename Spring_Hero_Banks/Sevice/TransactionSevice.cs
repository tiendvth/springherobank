﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Spring_Hero_Banks.entity;
using Spring_Hero_Banks.helper;
using SpringHeroBank2.model;

namespace Spring_Hero_Banks.service
{
    public class TransactionService
    {
        private Random _random = new Random();
        private ConnectionHelper _connectionHelper = new ConnectionHelper();
        private TransactionModel _transactionModel = new TransactionModel();

        public int GenerateRandomNumbers()
        {
            return int.Parse(_random.Next(10, 99).ToString() + _random.Next(10, 99).ToString() +
                             _random.Next(100, 999).ToString());
        }

     
        public Accout CheckUserExistence(string accountNumber)
        {
            var connection = _connectionHelper.Connection();
            var cmd = new MySqlCommand() {Connection = connection};
            Accout account = null;
            try
            {
                cmd.CommandText = $"SELECT * from accounts Where AccountNumber = '{accountNumber}'";
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        account = new Accout()
                        {
                            FullName = result["FullName"].ToString(),
                            Email = result["FullName"].ToString(),
                            PhoneNumber = result["Phone"].ToString(),
                            AccountNumber = result["AccountNumber"].ToString(),
                            BirthDay = result["Birthday"].ToString()
                        };
                    }
                }

                result.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Hiện tại không có kết nối vui lòng thử lại sau");
            }

            return account;
        }



        public Accout Recharge(Accout account,double amount)
        {
            return _transactionModel.Recharge(account.AccountNumber, amount, amount + account.Balance);
        }
        public Accout Withdrawal(Accout account,double amount)
        {
            return _transactionModel.Recharge(account.AccountNumber, amount,   account.Balance - amount);
        }


        public Accout Transfer(string sendCode,string recipientCode,double amount,string mess)
        {
            return _transactionModel.Transfer(sendCode, recipientCode, amount, mess);
        }

        public List<Transaction> TransactionHistory( string code)
        {
            return _transactionModel.TransactionHistory(code);
        }
        
    }
}