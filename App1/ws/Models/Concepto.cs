using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ws.Models
{
    public class Concepto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string ClaveSat { get; set; }
        public bool Sistema { get; set; }
        public decimal Exento { get; set; }

        public static Concepto cargar(int id) {
            var conx = Datos.conectar();
            var cmd = new SqlCommand("select nombre,tipo,claveSat,sistema,exento from conceptos where id = @id", conx);
            var c = new Concepto();
            SqlDataReader dr;
            cmd.Parameters.AddWithValue("@id", id);
            conx.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read()) {
                c.Id = id;
                c.Nombre = dr.GetString(0);
                c.Tipo = dr.GetString(1);
                c.ClaveSat = dr.GetString(2);
                c.Sistema = dr.GetString(3) == "S";
                c.Exento = dr.GetDecimal(4);
            }
            dr.Close();
            conx.Close();
            return c;
        }
        public static List<Concepto> lista()
        {
            var conx = Datos.conectar();
            var cmd = new SqlCommand("select id,nombre,tipo,claveSat,sistema,exento from conceptos order by tipo desc", conx);
            var l = new List<Concepto>();
            Concepto c;
            SqlDataReader dr;
            conx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = new Concepto();
                c.Id = dr.GetInt32(0);
                c.Nombre = dr.GetString(1);
                c.Tipo = dr.GetString(2);
                c.ClaveSat = dr.GetString(3);
                c.Sistema = dr.GetString(4) == "S";
                c.Exento = dr.GetDecimal(5);
                l.Add(c);
            }
            dr.Close();
            conx.Close();
            return l;
        }

    }
}