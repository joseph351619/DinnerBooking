using System.IO;
using System.Linq;
using System.Web.Mvc;
using DinnerBooking.Common;

namespace DinnerBooking.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                    viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                    ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        public class ModelStateWrapper : IValidationDictionary
        {
            private ModelStateDictionary _modelState { get; set; }
            public ModelStateWrapper(ModelStateDictionary modelStateDictionary)
            {
                _modelState = modelStateDictionary;
            }
            public void AddGeneralError(string errorMessage)
            {
                _modelState.AddModelError(string.Empty, errorMessage);
            }

            public bool Any()
            {
                return _modelState.Any();
            }

            public bool IsValid()
            {
                return _modelState.IsValid;
            }
        }

        public virtual JsonResult ApiResultWithData(object data)
        {
            return Json(new ApiModel()
            {
                success = ModelState.IsValid,
                message = ModelState[""]?.Errors[0].ErrorMessage,
                data = data
            }, JsonRequestBehavior.AllowGet);
        }
    }
}