using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnerBooking.Core.Data.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool MailSent { get; set; }
        [NotMapped]
        public string BookingContent { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Clear();
            builder.Append($"親愛的 {Name}\r\n\r\n");
            builder.Append($"我地收到你既訂單喇！\r\n\r\n");
            builder.Append($"送貨地址：{Address}\r\n");
            builder.Append($"聯絡電話：{Phone}\r\n\r\n");
            builder.Append($"貨品清單:\r\n\r\n");
            builder.Append($"{BookingContent}");
            builder.Append($"\r\n多謝幫襯！ - 每日晚餐敬上");
            return builder.ToString();
        }
    }
}
