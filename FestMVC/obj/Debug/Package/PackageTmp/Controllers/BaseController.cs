using FestMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestMVC.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationUserManager _activeUserManager;
        public ApplicationUserManager ActiveUserManager
        {
            get
            {
                return _activeUserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _activeUserManager = value;
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.IsAuthenticated)
            {
                ApplicationUser activeUser = ActiveUserManager.FindById(User.Identity.GetUserId());
                ViewBag.Name = activeUser.Name;
                ViewBag.UserImage = activeUser.UserImage;
            }
        }
    }
}