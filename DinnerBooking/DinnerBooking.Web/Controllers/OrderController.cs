using System.Web.Mvc;
using DinnerBooking.Core;
using DinnerBooking.Data;
using DinnerBooking.Data.Entities;

namespace DinnerBooking.Web.Controllers
{
    public class OrderController : BaseController
    {
        private Shop _shop;
        private Email _email;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _email = new Email(new BaseEntities());
            _shop = new Shop(Cart, new BaseEntities(), new ModelStateWrapper(ModelState));
            _shop.AfterBooking += _email.SendEmail;
        }
        private Cart Cart
        {
            get
            {
                if (Session["Cart"] == null)
                {
                    Session["Cart"] = new Cart();
                }
                return Session["Cart"] as Cart;
            }
            set => Session["Cart"] = value;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(_shop.GetCuisineCategories());
        }
        public ActionResult OrderPage(int categoryId)
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
        public ActionResult Purchase(int cuisineId)
        {
            _shop.PurchaseById(cuisineId);
            return base.ApiResultWithData(new
            {
                cuisineCountView = RenderRazorViewToString("_CuisineCount", Cart.CurrentCuisine.Limit - Cart.CurrentCuisine.Count),
                counterView = RenderRazorViewToString("_CartCount", Cart.Count)
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