using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ws.Controllers
{
    public class EmpresaController : Controller
    {
        [HttpPost]
        public string registrar(Models.Empresa emp) {
            return emp.registrar();
        }

        public JsonResult loguear(string rfc, string pwd) {
            var emp = Models.Empresa.loguear(rfc, pwd);
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
    }
}