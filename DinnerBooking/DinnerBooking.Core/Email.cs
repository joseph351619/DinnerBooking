using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DinnerBooking.Data.Entities;
using DinnerBooking.Repository;

namespace DinnerBooking.Core
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
        public Email(DbContext context)
        {
            _bookingRepository = new BookingRepository(context);
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
            Task.Run(() => client.SendAsync(
                "josephsungfu@gmail.com", 
                booking.Email,
                "每日晚餐訂單確認通知", 
                booking.ToString(), 
                
                new SendAsyncWithBookingId(booking.Id)));
        }
        private void SetEmailSent(object sender, AsyncCompletedEventArgs e)
        {
            var smtpClient = (SmtpClient)sender;
            var bookingInfo = (SendAsyncWithBookingId)e.UserState;
            smtpClient.SendCompleted -= SetEmailSent;
            var booking = _bookingRepository.ReadAll().FirstOrDefault(a => a.Id == bookingInfo.BookingId);
            if (booking != null)
                booking.MailSent = true;
            _bookingRepository.Save();
        }
        
    }
}
