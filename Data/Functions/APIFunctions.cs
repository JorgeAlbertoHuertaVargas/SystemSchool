using Entities.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
namespace Data.Functions
{
    public class APIFunctions //: IAPI
    {
        public readonly Webscraping webscraping = new Webscraping();
        public async Task<string> Consulta_DNIsyncAsync(string dNItext)
        {
            string mensajeRespuesta = "";
            var txtApellidoPaterno = "";
            var txtApellidoMaterno = "";
            var txtNombres = "";
            string numeroDNI = dNItext;
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler controladorMensaje = new HttpClientHandler();
            controladorMensaje.CookieContainer = cookies;
            controladorMensaje.UseCookies = true;
            using (HttpClient cliente = new HttpClient(controladorMensaje))
            {
                cliente.DefaultRequestHeaders.Add("Host", "eldni.com");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                cliente.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault; // Compliant; choice of the SSL/TLS versions rely on the OS configuration
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13; // Compliant
                string url = "https://eldni.com/pe/buscar-por-dni";
                using (HttpResponseMessage resultadoConsultaToken = await cliente.GetAsync(new Uri(url)))
                {
                    if (resultadoConsultaToken.IsSuccessStatusCode)
                    {
                        mensajeRespuesta = await resultadoConsultaToken.Content.ReadAsStringAsync();
                        string token = webscraping.ExtraerContenidoEntreNombreString(mensajeRespuesta, 0, "name=\"_token\" value=\"", "\">");
                        cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site");
                        cliente.DefaultRequestHeaders.Add("Origin", "https://eldni.com");
                        cliente.DefaultRequestHeaders.Add("Referer", "https://eldni.com/pe/buscar-por-dni");
                        cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                        ConsultaDNI oDatoSolicitudDNI = new ConsultaDNI();
                        oDatoSolicitudDNI._token = token;
                        oDatoSolicitudDNI.dni = numeroDNI;
                        using (HttpResponseMessage resultadoConsultaDatos = await cliente.PostAsJsonAsync(url, oDatoSolicitudDNI))
                        {
                            if (resultadoConsultaDatos.IsSuccessStatusCode)
                            {
                                string contenidoHTML = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                string nombreInicio = "<table class=\"table table-striped table-scroll\">";
                                string nombreFin = "</table>";
                                string contenidoDNI = webscraping.ExtraerContenidoEntreNombreString(contenidoHTML, 0, nombreInicio, nombreFin);
                                if (contenidoDNI == "")
                                {
                                    nombreInicio = "<h3 class=\"text-error\">";
                                    nombreFin = "</h3>";
                                    mensajeRespuesta = webscraping.ExtraerContenidoEntreNombreString(contenidoHTML, 0, nombreInicio, nombreFin);
                                    mensajeRespuesta = "";
                                }
                                else
                                {
                                    nombreInicio = "<td>";/////
                                    nombreFin = "</td>";
                                    string[] arrResultado = webscraping.ExtraerContenidoEntreNombre(contenidoDNI, 0,
                                        nombreInicio,
                                        nombreFin);
                                    if (arrResultado != null)
                                    {
                                        arrResultado = webscraping.ExtraerContenidoEntreNombre(contenidoDNI,
                                            Convert.ToInt32(arrResultado[0]),
                                            nombreInicio, nombreFin);
                                        if (arrResultado != null)
                                        {
                                            txtNombres = arrResultado[1];
                                            arrResultado = webscraping.ExtraerContenidoEntreNombre(contenidoDNI,
                                                Convert.ToInt32(arrResultado[0]),
                                                nombreInicio, nombreFin);
                                            if (arrResultado != null)
                                            {
                                                txtApellidoPaterno = arrResultado[1];
                                                arrResultado = webscraping.ExtraerContenidoEntreNombre(contenidoDNI,
                                                    Convert.ToInt32(arrResultado[0]),
                                                    nombreInicio, nombreFin);
                                                if (arrResultado != null)
                                                {
                                                    txtApellidoMaterno = arrResultado[1];
                                                    mensajeRespuesta = string.Format("Se realizó exitosamente la consulta del número de DNI {0}",
                                                                numeroDNI);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                mensajeRespuesta = await resultadoConsultaDatos.Content.ReadAsStringAsync();
                                return (mensajeRespuesta);
                            }
                        }
                    }
                    else
                    {
                        return (mensajeRespuesta + ' ' + resultadoConsultaToken);
                    }
                }
            }
            return ("T," + txtApellidoPaterno + "," + txtApellidoMaterno + "," + txtNombres + ",");
        }
    }
}

