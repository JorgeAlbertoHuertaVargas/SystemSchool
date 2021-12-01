using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Models.Language
{
    public class LanguageModelButtons
    {

        public string Register { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }
        public string Cancel { get; set; }
        public string Reset { get; set; }
        public string Title { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }
        public string Seccion { get; set; }
        public string Grado { get; set; }
        public string Apoderado { get; set; }
        public string Telefono { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
        public string List_Teacher { get; set; }
        public string Table_Teachers { get; set; }
        public string Add_Teacher { get; set; }

        public LanguageModelButtons GetLanguageForView()
        {
            var parameters = new Logic.ParametersSystemLogic.ParametersSystemLogic();
            LanguageModelButtons language;
            var jsonString = "";
            if (parameters.GetParametersSystemById(1).State)
            {

                jsonString = System.IO.File.ReadAllText("./Models/Language/" + parameters.GetParametersSystemById(1).Value + "/Buttons.json");
                language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);


                /* switch (parameters.GetParametersSystemById(1).Value)
                 {

                     case "English":
                         jsonString = System.IO.File.ReadAllText("./Models/Language/English/Buttons.json");
                         language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);
                         break;
                     case "Spanish":
                         jsonString = System.IO.File.ReadAllText("./Models/Language/Spanish/Buttons.json");
                         language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);
                         break;
                     case "Portuguese":
                         jsonString = System.IO.File.ReadAllText("./Models/Language/Portuguese/Buttons.json");
                         language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);
                         break;
                     default:
                         jsonString = System.IO.File.ReadAllText("./Models/Language/Spanish/Buttons.json");
                         language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);
                         break;
                 }*/
            }
            else
            {
                jsonString = System.IO.File.ReadAllText("./Models/Language/Spanish/Buttons.json");
                language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);
            }
            return language;
        }
    }
}
