using DinnerBooking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinnerBooking.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService = new OrderService(new DinnerBooking.Data.BaseEntities());
        // GET: Order
        public ActionResult Index()
        {
            return View(_orderService.GetCategories());
        }
        public ActionResult OrderPage(int categoryId)
        {
            return PartialView("_OrderPage", _orderService.GetCuisinesInCategory(categoryId));
        }
    }
}