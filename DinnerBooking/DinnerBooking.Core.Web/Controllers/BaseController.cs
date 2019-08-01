using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinnerBooking.Common;
using DinnerBooking.Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace DinnerBooking.Web.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class BaseController : Controller
    {
        protected BaseEntities Db;
        private ICompositeViewEngine _viewEngine;
        public BaseController(BaseEntities db, ICompositeViewEngine viewEngine)
        {
            Db = db;
            _viewEngine = viewEngine;
        }
        public async Task<string> RenderRazorViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult =
                    _viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
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
            });
        }
    }
}