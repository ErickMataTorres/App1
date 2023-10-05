using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ws.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpPost]
        public string guardar(Models.Empleado emp)
        {
            return emp.guardar();
        }

        // GET: Empleado
        public JsonResult cargar(int id, int empresa) {
            var emp = Models.Empleado.carga(id,empresa);
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        // GET: Lista empleados
        public JsonResult lista(int empresa, string filtro)
        {
            var lst = Models.EmpleadoLista.lista(empresa, filtro);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}