using System;
using System.Dynamic;

namespace Spring_Hero_Banks.entity
{
    public class Accout
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Salt { get; set; }

        public string BirthDay { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public string Passwordmd5 { get; set; }
        public int Status { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        private DateTime DeleteAt { get; set; }
       
    }
}