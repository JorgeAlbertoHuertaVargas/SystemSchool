using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Interfaces
{
    public interface IDegreeInterface
    {

        List<Levell> levels { get; set; }
        List<Degree> Degrees { get; set; }

        List<Degree> GetDegree();
        List<Levell> GetLevels();
        Degree GetDegree(int IdDegree);
        int CreateDegree(Degree degree);
        int UpdateDegree(Degree degree);
        int DeleteDegree(int IdDegree);
        bool CheckNameNoExists(string DegreeName);

        List<Degree> GetDegreeByIdLevel(int id);


    }
}