using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ws.Controllers
{
    public class ConceptoController : Controller
    {
        public JsonResult cargar(int id) {
            var c = Models.Concepto.cargar(id);
            return Json(c, JsonRequestBehavior.AllowGet);
        }
        public JsonResult lista()
        {
            var l = Models.Concepto.lista();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}