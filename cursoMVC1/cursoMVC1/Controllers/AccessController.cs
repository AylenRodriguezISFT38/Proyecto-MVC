using cursoMVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cursoMVC1.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    var lst =  from d in db.user
                               where d.email == user && d.password == password && d.idState == 1 select d;
                    if (lst.Count()>0)
                    {
                        user oUser = lst.First();
                        Session["User"] = oUser;

                        return Content("1");
                    }
                    else
                    {

                        return Content("Usuario invalido");
                    }
                }
            }
            catch (Exception)
            {

                return Content("Acceso denegado");
            }
        }
       
    }
}