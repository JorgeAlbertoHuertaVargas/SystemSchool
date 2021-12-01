using Logic.ParametersSystemLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ParametersSystem : Controller
    {

        private readonly ParametersSystemLogic parametersLogic = new ParametersSystemLogic();
        public IActionResult Index()
        {
            return View(parametersLogic.GetAllParametersSystem());
        }

        [HttpPost]
        public IActionResult Update(int id, string value, int state)
        {
            bool stateBool = true;
            if (state == 0)
            {
                stateBool = false;
            }
            parametersLogic.UpdateParametersSystem(id, value, stateBool);
            return RedirectToAction("Index");
        }
    }
}
