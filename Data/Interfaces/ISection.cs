using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ISection
    {
        public List<Section> GetAllSection();
        public void AddSections(Section sect);
        public Section GetSection(int idsection);
        public bool Edit(Section sec);
        public bool DeleteSection(int id);

    }
}
