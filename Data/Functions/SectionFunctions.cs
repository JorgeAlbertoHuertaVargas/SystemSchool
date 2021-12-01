using Data.DataContext;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using System.Data;

namespace Data.Functions
{
    public class SectionFunctions : ISection
    {

        //Get All Sections
        public List<Section> GetAllSection()
        {
            List<Section> section = new List<Section>();
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var cantidad = db.Sections.Count();
                {
                    if (cantidad > 0)
                    {
                        return db.Sections.ToList();
                    }


                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar las secciones.", e);
            }

            return section;


        }

        public void AddSections(Section sect)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            db.Sections.Add(sect);
            db.SaveChanges();

        }

        public Section GetSection(int idsection)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            return db.Sections.Find(idsection);

        }


        public bool Edit(Section sec)
        {
            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var s = db.Sections.Find(sec.IdSection);

                if (s != null)
                {
                    s.SectionName = sec.SectionName;
                    s.Detail = sec.Detail;
                    db.SaveChanges();

                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al actualizar los datos de la sección", ex);
            }

            return confirmar;



        }

        public bool DeleteSection(int id)
        {

            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var s = db.Sections.Find(id);

                if (s != null)
                {
                    db.Sections.Remove(s);
                    db.SaveChanges();

                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al eliminar la sección", ex);
            }

            return confirmar;

        }
    }
}
