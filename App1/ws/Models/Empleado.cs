using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace ws.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public int Empresa { get; set; }
        public string Nombre { get; set; }
        public string ApePat { get; set; }
        public string ApeMat { get; set; }
        public string Puesto { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime FechaIngreso { get; set; }

        public static Empleado carga(int id, int empresa) {
            var emp = new Empleado();
            var conx = Datos.conectar();
            var cmd = new SqlCommand("select nombre,apeMat,apePat,puesto,sueldo,fechaIngreso from empleados where id = @id and empresa = @emp", conx);
            SqlDataReader dr;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@emp", empresa);
            conx.Open();
            dr = cmd.ExecuteReader();
            if(dr.Read()){
                emp.Id = id;
                emp.Empresa = empresa;
                emp.Nombre = dr.GetString(0);
                emp.ApePat = dr.GetString(1);
                emp.ApeMat = dr.GetString(2);
                emp.Puesto = dr.GetString(3);
                emp.Sueldo = dr.GetDecimal(4);
                emp.FechaIngreso = dr.GetDateTime(5);
            }
            dr.Close();
            conx.Close();
            return emp;
        }
        public string guardar() {
            var res = "";
            var conx = Datos.conectar();
            var cmd = new SqlCommand("grabaEmpleado", conx);
            var prm = new SqlParameter("@idReal", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@empresa", Empresa);
            cmd.Parameters.AddWithValue("@apePat", ApePat);
            cmd.Parameters.AddWithValue("@apeMat", ApeMat);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@puesto", Puesto);
            cmd.Parameters.AddWithValue("@sueldo", Sueldo);
            cmd.Parameters.AddWithValue("@fechaIngreso", FechaIngreso);
            cmd.Parameters.Add(prm);
            try
            {
                conx.Open();
                cmd.ExecuteNonQuery();
                res = prm.Value.ToString();
                conx.Close();
            }
            catch (Exception ex) {
                res = "Error, " + ex.Message;
                if (conx.State == ConnectionState.Open)
                    conx.Close();
            }
            return res;
        }
    }
    public class EmpleadoLista {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }


        public static List<EmpleadoLista> lista(int empresa, string filtro)
        {
            var lst = new List<EmpleadoLista>();
            var conx = Datos.conectar();
            var cmd = new SqlCommand("listaEmpleados", conx);
            EmpleadoLista e;
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empresa", empresa);
            cmd.Parameters.AddWithValue("@filtro", filtro + "%");
            conx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                e = new EmpleadoLista();
                e.Id = dr.GetInt32(0);
                e.Nombre = dr.GetString(1);
                e.Puesto = dr.GetString(2);
                lst.Add(e);
            }
            dr.Close();
            conx.Close();
            return lst;
        }

    }
}