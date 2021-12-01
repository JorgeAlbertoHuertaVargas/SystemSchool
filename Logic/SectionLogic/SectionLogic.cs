using Data.Functions;
using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SectionLogic
{
    public class SectionLogic
    {
        private readonly ISection obj = new SectionFunctions();


        //GetAllSections
        public List<Section> GetAllSections()
        {
            try
            {
                return obj.GetAllSection();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al traer los datos de sección", e);
            }
        }

        //AddSections
        public void AddSections(Section sect)
        {
            try
            {
                obj.AddSections(sect);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al agregar los datos de sección", e);
            }

        }

        public Section GetSection(int idsection)
        {
            try
            {
                return obj.GetSection(idsection);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al extraer los datos de sección", e);
            }

        }

        public bool Edit(Section sec)
        {
            try
            {
                return obj.Edit(sec);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al editar los datos de sección", e);
            }

        }

        public bool Eliminar(int id)
        {
            try
            {
                return obj.DeleteSection(id);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al eliminar la sección", e);
            }

        }


    }
}
