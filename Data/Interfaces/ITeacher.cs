using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ITeacher
    {
        public List<Teacher> GetAllTeacher();
        Teacher AddTeacher(Teacher teacher);
        public Teacher GetTeacher(int idteacher);
        public bool Edit(Teacher teacher);
        public bool DeleteTeacher(int id);
    }
}
