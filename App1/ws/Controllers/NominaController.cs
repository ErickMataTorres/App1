using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ws.Controllers
{
    public class NominaController : Controller
    {
        [HttpPost]
        public string guardar(int empleado, int empresa, string conceptos) {
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Captura>>(conceptos);
            return Models.Captura.guardar(empresa, empleado, lst);
        }

        public JsonResult captura(int empleado, int empresa) {
            var cap = Models.Captura.cargar(empresa, empleado);
            return Json(cap, JsonRequestBehavior.AllowGet);
        }
    }
}