using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.clases
{
    public class Servicio
    {
        public static string URLBase = "http://practicasudo.isaerpweb.com";

        public static async Task<Empresa> loguear(string rfc, string pwd)
        {
            var url = URLBase + "/empresa/loguear";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("rfc",rfc),
                new KeyValuePair<string,string>("pwd",pwd)
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<Empresa>(json);
            return dato;
        }
        public static async Task<string> registrar(Empresa emp)
        {
            var url = URLBase + "/empresa/registrar";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("Id","0"),
                new KeyValuePair<string,string>("Nombre",emp.Nombre),
                new KeyValuePair<string,string>("Rfc",emp.Rfc),
                new KeyValuePair<string,string>("RegImss",emp.RegImss),
                new KeyValuePair<string,string>("Regimen",emp.Regimen),
                new KeyValuePair<string,string>("Periodicidad",emp.Periodicidad),
                new KeyValuePair<string,string>("Pwd",emp.Pwd)
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var dato = await res.Content.ReadAsStringAsync();
            return dato;
        }

        public static async Task<string> grabaEmpleado(Empleado emp)
        {
            var url = URLBase + "/empleado/guardar";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("Id",emp.Id.ToString()),
                new KeyValuePair<string,string>("Empresa",emp.Empresa.ToString()),
                new KeyValuePair<string,string>("Nombre",emp.Nombre),
                new KeyValuePair<string,string>("ApePat",emp.ApePat),
                new KeyValuePair<string,string>("ApeMat",emp.ApeMat),
                new KeyValuePair<string,string>("Puesto",emp.Puesto),
                new KeyValuePair<string,string>("Sueldo",emp.Sueldo.ToString()),
                new KeyValuePair<string,string>("FechaIngreso",emp.FechaIngreso.ToString("dd/MM/yyyy"))
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var dato = await res.Content.ReadAsStringAsync();
            return dato;
        }

        public static async Task<Empleado> cargarEmpleado(int id, int emp) {
            var url = URLBase + "/empleado/cargar";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("id",id.ToString()),
                new KeyValuePair<string,string>("empresa",emp.ToString())
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<Empleado>(json);
            return dato;
        }
        public static async Task<List<EmpleadoLista>> listaEmpleados(int emp, string filtro)
        {
            var url = URLBase + "/empleado/lista";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("filtro",filtro),
                new KeyValuePair<string,string>("empresa",emp.ToString())
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<List<EmpleadoLista>>(json);
            return dato;
        }
        public static async Task<List<Concepto>> cargarConceptos()
        {
            var url = URLBase + "/concepto/lista";
            var ws = new HttpClient();
            var res = await ws.PostAsync(url, null).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<List<Concepto>>(json);
            return dato;
        }
        public static async Task<List<Captura>> cargarCaptura(int empresa, int empleado)
        {
            var url = URLBase + "/nomina/captura";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("empresa",empresa.ToString()),
                new KeyValuePair<string,string>("empleado",empleado.ToString())
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<List<Captura>>(json);
            return dato;
        }
        public static async Task<List<CatalogoSat>> cargarRegimenes()
        {
            var url = URLBase + "/catalogo/regimenes";
            var ws = new HttpClient();
            var res = await ws.PostAsync(url, null).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<List<CatalogoSat>>(json);
            return dato;
        }
        public static async Task<List<CatalogoSat>> cargarPeriodicidades()
        {
            var url = URLBase + "/catalogo/periodicidades";
            var ws = new HttpClient();
            var res = await ws.PostAsync(url, null).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<List<CatalogoSat>>(json);
            return dato;
        }
    }
}