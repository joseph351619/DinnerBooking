using System.Configuration;
using DinnerBooking.Core.Core;
using DinnerBooking.Core.Data;
using DinnerBooking.Core.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DinnerBooking.Web.Controllers
{
    public class OrderController : BaseController
    {
        private Shop _shop;
        private Email _email;
        private readonly string SessionCart = "Cart";

        public OrderController(BaseEntities db, IConfiguration configuration, ICompositeViewEngine viewEngine) : base(db, viewEngine)
        {
            _email = new Email(Db, configuration);
        }
        private Cart _cart;
        private Cart Cart
        {
            get => _cart ?? (_cart = new Cart());
            set => _cart = value;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cart = HttpContext.Session.GetObject<Cart>(SessionCart);
            _shop = new Shop(Cart, Db, new ModelStateWrapper(ModelState));
            _shop.AfterBooking += _email.SendEmail;
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            HttpContext.Session.SetObject(SessionCart, Cart);
            base.OnActionExecuted(context);
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(_shop.GetCuisineCategories());
        }
        public ActionResult _OrderPage(int categoryId)
        {
            return base.ApiResultWithData(new
            {
                shopView = RenderRazorViewToString("_OrderPage", _shop.DisplayByCategory(categoryId)),
                counterView = RenderRazorViewToString("_CartCount", Cart.Count)
            });
        }
        public ActionResult _CheckOut()
        {
            return base.ApiResultWithData(new
            {
                shopView = RenderRazorViewToString("_CheckOut", Cart),
                counterView = RenderRazorViewToString("_CartCount", Cart.Count)
            });
        }
        public ActionResult _CheckOutPurchase(int cuisineId, Cart.Disposition disposition)
        {
            _shop.CheckOutPurchase(cuisineId, disposition);
            return base.ApiResultWithData(new
            {
                shopView = RenderRazorViewToString("_CheckOut", Cart),
                counterView = RenderRazorViewToString("_CartCount", Cart.Count)
            });
        }
        public ActionResult _Purchase(int cuisineId)
        {
            _shop.PurchaseById(cuisineId);
            return base.ApiResultWithData(new
            {
                cuisineCountView = RenderRazorViewToString("_CuisineCount", Cart.CurrentCuisine.Limit - Cart.CurrentCuisine.Count),
                counterView = RenderRazorViewToString("_CartCount", Cart.Count),
                cuisineCount = Cart.CurrentCuisine.Limit - Cart.CurrentCuisine.Count
            });
        }
        public ActionResult FinishCheckOut(Booking booking)
        {
            _shop.CheckOut(booking);
            Cart.Clear();
            return ApiResultWithData(null);
        }
    }
}