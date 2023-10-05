using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ws.Models
{
    public class CatalogoSat
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public static List<CatalogoSat> periodicidades() {
            CatalogoSat c;
            List<CatalogoSat> lista = new List<CatalogoSat>();
            SqlConnection conx = Datos.conectar();
            SqlCommand cmd = new SqlCommand("select id,nombre from periodicidad order by id", conx);
            SqlDataReader dr;
            conx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read()) {
                c = new CatalogoSat();
                c.Id = dr.GetString(0);
                c.Nombre = dr.GetString(1);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public static List<CatalogoSat> regimenes()
        {
            CatalogoSat c;
            List<CatalogoSat> lista = new List<CatalogoSat>();
            SqlConnection conx = Datos.conectar();
            SqlCommand cmd = new SqlCommand("select id,nombre from regimen order by id", conx);
            SqlDataReader dr;
            conx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c = new CatalogoSat();
                c.Id = dr.GetString(0);
                c.Nombre = dr.GetString(1);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}