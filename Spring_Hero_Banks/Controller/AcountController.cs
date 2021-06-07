﻿using System;
using Spring_Hero_Banks.entity;
using Spring_Hero_Banks.service;
namespace Spring_Hero_Banks.controller
{
    public class AccountController
    {
        private TransactionService _transactionService = new TransactionService();

        public Accout Recharge(Accout account)
        {
            Console.WriteLine("\nNhập vào số tiền bạn muốn nạp :");
            var amount = double.Parse(Console.ReadLine());
            if (amount <= 0)
            {
                Console.WriteLine($"\nKhông thể nạp ${amount} vào ví , yêu cầu nạp tối thiểu từ $1\n");
                return account;
            }
            else
            {
                Console.WriteLine("\nXác nhận nạp tiền\nChọn 1 để tiếp tục\nChọn 2 để bỏ qua\n");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine($"\nĐã nạp thành công ${amount} vào tài khoản\n");
                    return _transactionService.Recharge(account,amount);
                }
                else
                {
                    return account;
                }
            }
        }
        
        public Accout Withdrawal(Accout account)
        {
            Console.WriteLine("\nNhập vào số tiền bạn muốn rút :");
            var amount = double.Parse(Console.ReadLine());
            if (amount > account.Balance)
            {
                Console.WriteLine($"\nKhông thể rút ${amount} vì tài khoản của bạn không đủ\n");
                return account;
            }
            else
            {
                Console.WriteLine("\nXác nhận rút tiền\nChọn 1 để tiếp tục\nChọn 2 để bỏ qua\n");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine($"\nĐã rút thành công ${amount} từ tài khoản\n");
                    return _transactionService.Withdrawal(account,amount);;
                }
                else
                {
                    return account;
                }
            }
        }

        public Accout Transfer(Accout account)
        {
            Accout user = null;
            Console.WriteLine("\nNhập mã người nhận");
            var recipientCode = Console.ReadLine();

            if (recipientCode == account.AccountNumber)
            {
                Console.WriteLine("\nBạn không thể tự chuyển tiền cho chính mình !\n");
                return account;
            }
            else
            {
                var checkAccount = _transactionService.CheckUserExistence(recipientCode);
                if (checkAccount == null)
                {
                    Console.WriteLine($"\nKhông tìm thấy thông tin người dùng nào tương ứng với : {recipientCode}\n");
                    return account;
                }
                else
                {
                    Console.WriteLine(
                        $"\nTìm thấy người dùng : {checkAccount.FullName} tương ứng với : mã số : {checkAccount.AccountNumber}\n");
                    Console.WriteLine("Chọn 1 để tiếp tục \nChọn 2 để bỏ qua\n");
                    var choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine("\nNhập vào số tiền bạn muốn chuyển");
                        var amount = double.Parse(Console.ReadLine());
                        if (amount > account.Balance)
                        {
                            Console.WriteLine("\n Tài khoản của bạn không đủ\n");
                            return account;
                        }
                        Console.WriteLine("\nNhập vào message bạn muốn gửi");
                        var mess = Console.ReadLine();
                        return _transactionService.Transfer(account.AccountNumber, checkAccount.AccountNumber, amount, mess);
                    }
                    else
                    {
                        Console.WriteLine("\nĐã hủy giao dịch");
                        return account;
                    }
                }
            }
        }

        public void ShowTransactionHistory(Accout account)
        {
            var transactions = _transactionService.TransactionHistory(account.AccountNumber);
            if (transactions.Count == 0)
            {
                Console.WriteLine("\nBạn chưa có giao dịch nào\n");
            }
            else
            {
                foreach (var transaction in transactions)
                {
                    transaction.ToString();
                }
            }
        }

        public void ShowInformation(Accout account)
        {
            Console.WriteLine("\n\n||======================| Information |====================||");
            Console.WriteLine($"- Người dùng : {account.FullName}");
            Console.WriteLine($"- Số dư tài khoản : ${account.Balance}");
            Console.WriteLine($"- Mã số tài khoản : {account.AccountNumber}");
            Console.WriteLine($"- Số điện thoại : {account.PhoneNumber}");
            Console.WriteLine($"- Email : {account.Email}");
            Console.WriteLine($"- Bảo mật : {account.Passwordmd5}");
            Console.WriteLine($"- Ngày sinh : {account.BirthDay}");
            Console.WriteLine($"- Ngày tham gia : {account.CreatedAt}");
            Console.WriteLine("||======================| Information |====================||\n\n");
        }
    }
}