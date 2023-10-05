using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ws.Controllers
{
    public class CatalogoController : Controller
    {
        public JsonResult periodicidades() {
            var lista = Models.CatalogoSat.periodicidades();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult regimenes()
        {
            var lista = Models.CatalogoSat.regimenes();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        // GET: Catalogo
        public ActionResult Index()
        {
            return View();
        }
    }
}