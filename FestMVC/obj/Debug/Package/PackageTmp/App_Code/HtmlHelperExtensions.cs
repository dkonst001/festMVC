using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FestMVC.App_Code
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ToggleSwitchFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            return htmlHelper.DropDownListFor(expression, new[]
            {
                new SelectListItem { Text = "No", Value = "false" },
                new SelectListItem { Text = "Yes", Value = "true" }
                }, new { @class = "toggleswitch" });
        }
    }
}