using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DinnerBooking.Core.Data;
using DinnerBooking.Core.Data.Entities;
using DinnerBooking.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DinnerBooking.Core.Core
{
    public class SendAsyncWithBookingId
    {
        public int BookingId { get; private set; }

        public SendAsyncWithBookingId(int bookingId)
        {
            this.BookingId = bookingId;
        }
    }
    public class Email
    {
        private readonly BookingRepository _bookingRepository;
        private readonly IConfiguration _configuration;
        public Email(DbContext context, IConfiguration configuration)
        {
            _bookingRepository = new BookingRepository(context);
            _configuration = configuration;
        }
        public void SendEmail(Booking booking)
        {
            if (booking == null) throw new ArgumentNullException(nameof(booking));
            
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("josephsungfu@gmail.com", "qqgmnxhistkphdci"),
                EnableSsl = true,
            };
            client.SendCompleted += SetEmailSent;
            Task.Factory.StartNew(() =>
                client.SendAsync(
                    "josephsungfu@gmail.com",
                    booking.Email,
                    "每日晚餐訂單確認通知",
                    booking.ToString(),
                    new SendAsyncWithBookingId(booking.Id))
                );
        }
        private void SetEmailSent(object sender, AsyncCompletedEventArgs e)
        {
            var builder = new DbContextOptionsBuilder<BaseEntities>();
            builder.UseSqlServer(_configuration.GetConnectionString("DinnerBookingDataBase"));
            var context = new BaseEntities(builder.Options);
            var bookingRepository = new BookingRepository(context);

            var smtpClient = (SmtpClient)sender;
            var bookingInfo = (SendAsyncWithBookingId)e.UserState;
            smtpClient.SendCompleted -= SetEmailSent;
            var booking = bookingRepository.ReadAll().FirstOrDefault(a => a.Id == bookingInfo.BookingId);
            if (booking != null)
                booking.MailSent = true;
            bookingRepository.Save();
        }
        
    }
}
