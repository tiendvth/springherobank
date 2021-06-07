using System;
using System.Text;

namespace Spring_Hero_Banks.entity
{
    public class Transaction
    {
        public int id { get; set; }
       public double Amount { get; set; }
       
       private string code { get; set; }
       
       public object Sendercode { get; set; }
       
       public string ReceiverCode { get; set; }

       public int Type { get; set; }
       
       private string Messenge { get; set; }
       public DateTime CreateAt { get; set; }
       public DateTime UpdateAt { get; set; }
       public DateTime DeleteAt { get; set; }
       public string Message { get; set; }

       public void ToString()
       {
           Console.OutputEncoding = Encoding.UTF8;
           string trannTXT = "";
           if (this.Type == 1)
           {
               trannTXT = "Rút tiền";
           }
           else if (this.Type == 2)
           {
               trannTXT = "Nạp tiền";
           }
           else if (this.Type == 3)
           {
               trannTXT = "Chuyển tiền";
           }

           Console.WriteLine(
               value: $"|| Mã giao dịch : {id} \t số tiền giao dịch ${Amount} \t người thực hiện : {Sendercode} \t người nhận : {ReceiverCode} \t loại giao dịch : {trannTXT}\n" +
                      $"|| Message : {Message} \t ngày tạo : {CreateAt} \t ngày sửa : {UpdateAt}" +
                      $"\n|| --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
       }
    }
}