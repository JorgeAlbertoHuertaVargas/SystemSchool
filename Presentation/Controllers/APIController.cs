using Logic.APPLogic;

using Microsoft.AspNetCore.Mvc;
using System;

using System.Threading.Tasks;

namespace Presentation.Controllers
{

    public class APIController : Controller
    {
        private readonly APPLogic _CapaLogicApi = new APPLogic();

        public ActionResult Index()
        {
            return View();
        }
        //PETICION POST A URL :https://aplicaciones007.jne.gob.pe

        //PETICION POST A URL :https://eldni.com/pe/buscar-por-dni
        [HttpPost]
        public async Task<string> Consulta_DNIAsync(String DNItext)
        {

            Task<String> resp = (Task<string>)_CapaLogicApi.ConsultarDNIAsync(DNItext);
            String result = await resp;
            return result;
        }
    }


}
