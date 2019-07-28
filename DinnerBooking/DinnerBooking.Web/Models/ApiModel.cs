
namespace DinnerBooking.Web.Models
{
    public class ApiModel
    {
        public ApiModel() { }
        public ApiModel(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}