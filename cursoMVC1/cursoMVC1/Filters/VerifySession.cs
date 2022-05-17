using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursoMVC1.Models;
using cursoMVC1.Controllers;

namespace cursoMVC1.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //obtener la seccion
            var oUser = (user)HttpContext.Current.Session["User"];
            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index2");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Alumno/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}