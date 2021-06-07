using System;
using Spring_Hero_Banks.entity;
using Spring_Hero_Banks.helper;
using Spring_Hero_Banks.model;

namespace Spring_Hero_Banks.service
{
    public class AccountService
    {
        private Random _random = new Random();
        private Md5 _md5Helper = new Md5();
        private AccountModel _accountModel = new AccountModel();


        public void CreateAccountService(Accout account)
        {
            var salt = _random.Next(100000000, 999999999).ToString();
            
            var accountNumber = _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString();
            
            var passwordHash = _md5Helper.PasswordHash(account.Passwordmd5, salt);
           
            var accountCreate = new Accout()
            {
                FullName = account.FullName,
                Email = account.Email,
                PhoneNumber = account.PhoneNumber,
                BirthDay = account.BirthDay,
                Passwordmd5 = passwordHash,
                Salt = salt,
                AccountNumber = accountNumber,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            
            var created = _accountModel.CreateNewAccount(accountCreate);
            if (created)
            {
                Console.WriteLine($"\nTạo mới tài khoản thành công mã số tài khoản của bạn là : {accountNumber}\n");
            }
            else
            {
                Console.WriteLine("\nTạo tài khoản thất bại vui lòng kiểm tra lại kết nối !\n");
            }
        }
    }
}