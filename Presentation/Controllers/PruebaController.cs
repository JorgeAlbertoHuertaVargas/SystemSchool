using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class PruebaController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                string endpoint = "https://api.sunat.cloud/ruc/20164113532";

                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string json = reader.ReadToEnd();

                RUC ruc = JsonConvert.DeserializeObject<RUC>(json);

                Console.WriteLine($"Razon Social: {ruc.ruc}");
                Console.WriteLine($"RUC: {ruc.razon_social}");
                Console.WriteLine($"Nombre Comercial: {ruc.nombre_comercial}");
                Console.WriteLine($"Estado: {ruc.contribuyente_estado}");
                //...

                if (ruc.representante_legal.Count > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("----- Representante(s) Legal(es)---");
                    Console.WriteLine("-----------------------------------");

                    foreach (var item in ruc.representante_legal)
                    {
                        Console.WriteLine($"-> {item.Key.ToString()}");

                        Console.WriteLine($"Nombre: {item.Value.nombre}");
                        Console.WriteLine($"Cargo: {item.Value.cargo}");
                        Console.WriteLine($"Desde: {item.Value.desde}");

                        Console.WriteLine("-----------------------------------");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("------- Nro(s) Empleado(s) --------");
                    Console.WriteLine("-----------------------------------");

                    foreach (var item in ruc.empleados)
                    {
                        Console.WriteLine($"Año-mes: {item.Key.ToString()}");

                        Console.WriteLine($"Trabajadores: {item.Value.trabajadores}");
                        Console.WriteLine($"Pensionistas: {item.Value.pensionistas}");
                        Console.WriteLine($"Prestadores Servicio: {item.Value.prestadores_servicio}");

                        Console.WriteLine("-----------------------------------");
                    }
                }


                //Console.WriteLine(json);
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                Console.Read();
                //throw;
            }

            return View();
        }
    }
    public class RUC
    {
        public string ruc { get; set; }
        public string razon_social { get; set; }
        public string ciiu { get; set; }
        public string fecha_actividad { get; set; }
        public string contribuyente_condicion { get; set; }
        public string contribuyente_tipo { get; set; }
        public string contribuyente_estado { get; set; }
        public string nombre_comercial { get; set; }
        public string fecha_inscripcion { get; set; }
        public string domicilio_fiscal { get; set; }
        public string sistema_emision { get; set; }
        public string sistema_contabilidad { get; set; }
        public string actividad_exterior { get; set; }
        public string emision_electronica { get; set; }
        public string fecha_inscripcion_ple { get; set; }
        public string Oficio { get; set; }
        public string fecha_baja { get; set; }
        public Dictionary<string, RepresentaLegal> representante_legal { get; set; }
        public Dictionary<string, Empleado> empleados { get; set; }
        public string[] locales { get; set; }
    }

    public class RepresentaLegal
    {
        public string nombre { get; set; }
        public string cargo { get; set; }
        public string desde { get; set; }
    }

    public class Empleado
    {
        public string trabajadores { get; set; }
        public string pensionistas { get; set; }
        public string prestadores_servicio { get; set; }
    }
}
