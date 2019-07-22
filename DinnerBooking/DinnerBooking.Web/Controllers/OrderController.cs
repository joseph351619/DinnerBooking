using DinnerBooking.Service;
using DinnerBooking.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DinnerBooking.Data.Entities;
using DinnerBooking.Data.DTO;

namespace DinnerBooking.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService = new OrderService(new DinnerBooking.Data.BaseEntities());
        private BuyingCart BuyingCart
        {
            get
            {
                if (Session["BuyingCart"] == null)
                {
                    Session["BuyingCart"] = new BuyingCart();
                }
                return Session["BuyingCart"] as BuyingCart;
            }
            set => Session["BuyingCart"] = value;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(_orderService.GetCategories());
        }
        public ActionResult OrderPage(int categoryId)
        {
            return PartialView("_OrderPage", _orderService.GetCuisinesInCategory(categoryId, BuyingCart));
        }
        public ActionResult _CheckOut()
        {
            return PartialView("_CheckOut", BuyingCart);
        }
        public ActionResult _CheckOutPurchase(int cuisineId, bool? addOne)
        {
            _orderService.CheckOutPurchase(cuisineId, addOne, BuyingCart);
            return PartialView("_CheckOut", BuyingCart);
        }
        public ActionResult Purchase(int cuisineId)
        {
            bool isSuccess = false;
            string errorMsg = string.Empty;
            var cuisine = _orderService.GetCuisineById(cuisineId);
            if (cuisine != null)
            {
                isSuccess = _orderService.PurchaseCuisine(cuisine, BuyingCart, out errorMsg);
            }
            return Json(new ApiModel()
            {
                success = isSuccess,
                message = errorMsg,
                data = new {
                    count = cuisine?.Count,
                    total = BuyingCart.Count
                }
            },JsonRequestBehavior.AllowGet);
        }
    }
}