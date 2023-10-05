using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ws.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rfc { get; set; }
        public string RegImss { get; set; }
        public string Regimen { get; set; }
        public string Periodicidad { get; set; }
        public string Pwd { get; set; }

        public static Empresa loguear(string rfc, string pwd) {
            var conx = Datos.conectar();
            Empresa emp = new Empresa();
            SqlCommand cmd = new SqlCommand("select id,nombre,regImss,regimen,periodicidad from empresas where rfc = @rfc and pwd = @pwd", conx);
            SqlDataReader dr;
            cmd.Parameters.AddWithValue("@rfc", rfc);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            conx.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read()) {
                emp.Id = dr.GetInt32(0);
                emp.Nombre = dr.GetString(1);
                emp.RegImss = dr.GetString(2);
                emp.Regimen = dr.GetString(3);
                emp.Periodicidad = dr.GetString(4);
                emp.Rfc = rfc;
                emp.Pwd = pwd;
            }
            dr.Close();
            conx.Close();
            return emp;
        }
        public string registrar() {
            string res = "";
            var conx = Datos.conectar();
            SqlCommand cmd = new SqlCommand("creaEmpresa", conx);
            SqlParameter prm = new SqlParameter("@id", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@rfc", Rfc);
            cmd.Parameters.AddWithValue("@regImss", RegImss);
            cmd.Parameters.AddWithValue("@regimen", Regimen);
            cmd.Parameters.AddWithValue("@periodicidad", Periodicidad);
            cmd.Parameters.AddWithValue("@pwd",Pwd);
            cmd.Parameters.Add(prm);
            try
            {
                conx.Open();
                cmd.ExecuteNonQuery();
                Id = (int)prm.Value;
                conx.Close();
                res = Id.ToString();
            }
            catch (Exception ex) {
                if (conx.State == ConnectionState.Open)
                    conx.Close();
                res = "Error, " + ex.Message;
            }
            return res;
        }
    }
}