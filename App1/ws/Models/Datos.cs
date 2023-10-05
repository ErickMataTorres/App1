using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ws.Models
{
    public class Datos
    {
        public static SqlConnection conectar() {
            var conx = new SqlConnection("server =  198.38.83.33; DataBase = ceguzman_practicasUdO; user id = ceguzman_alumnos; pwd = abc123");
            return conx;
        }
    }
}