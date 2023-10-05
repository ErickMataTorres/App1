using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ws.Models
{
    public class Captura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Importe { get; set; }

        public static List<Captura> cargar(int empresa, int empleado)
        {
            var conx = Datos.conectar();
            var cmd = new SqlCommand("capturaEmpleado", conx);
            var l = new List<Captura>();
            Captura c;
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empresa", empresa);
            cmd.Parameters.AddWithValue("@empleado", empleado);
            conx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = new Captura();
                c.Id = dr.GetInt32(0);
                c.Tipo = dr.GetString(1);
                c.Nombre = dr.GetString(2);
                c.Importe = dr.GetDecimal(3);
                l.Add(c);
            }
            dr.Close();
            conx.Close();
            return l;
        }
        public static string guardar(int empresa, int empleado, List<Captura> conceptos) {
            var res = "ok";
            var conx = Datos.conectar();
            var cmdA = new SqlCommand("borraCaptura", conx);
            var cmdB = new SqlCommand("grabaCaptura", conx);
            SqlTransaction tr = null;

            cmdA.CommandType = CommandType.StoredProcedure;
            cmdA.Parameters.AddWithValue("@empresa", empresa);
            cmdA.Parameters.AddWithValue("@empleado", empleado);

            cmdB.CommandType = CommandType.StoredProcedure;
            cmdB.Parameters.AddWithValue("@empresa", empresa);
            cmdB.Parameters.AddWithValue("@empleado", empleado);
            cmdB.Parameters.AddWithValue("@concepto", 0);
            cmdB.Parameters.AddWithValue("@importe", 0.00M);

            try
            {
                conx.Open();
                tr = conx.BeginTransaction();
                cmdA.Transaction = tr;
                cmdB.Transaction = tr;
                cmdA.ExecuteNonQuery();
                foreach (var c in conceptos)
                {
                    cmdB.Parameters["@concepto"].Value = c.Id;
                    cmdB.Parameters["@importe"].Value = c.Importe;
                    cmdB.ExecuteNonQuery();
                }
                tr.Commit();
                conx.Close();
            }
            catch (Exception ex) {
                if (tr != null)
                    tr.Rollback();
                if (conx.State == ConnectionState.Open)
                    conx.Close();
                res = "Error, " + ex.Message;
            }

            return res;
        }
    }
}