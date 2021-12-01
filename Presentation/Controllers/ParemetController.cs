using Data.DataContext;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ParemetController : Controller
    {
      

        public ActionResult Index()
        {
            return View();
        }

        // GET: ParemetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public List<Paremet> GetParamets()
        {
            using (var _conext = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {

                return _conext.Paramets.Include(sh => sh.Roles).ToList();

            }

        }

        public async Task<IActionResult> Registrar(int ParemetId, bool Statusnew, int RoleId)
        {
            var nuevo = ParemetId;

            var nuestarus = Statusnew;

            var dever = RoleId;


            using (var _conext = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                var dbParemet = await _conext.Paramets
                .Include(sh => sh.Roles)
                .FirstOrDefaultAsync(h => h.ParemetId == ParemetId);
                if (dbParemet == null)
                    return NotFound("Super Hero wasn't found. Too bad. :(");
                dbParemet.Status = Statusnew;
                dbParemet.RoleId = RoleId;
                await _conext.SaveChangesAsync();
                return Ok(dbParemet);
            }
        }

    }
}
