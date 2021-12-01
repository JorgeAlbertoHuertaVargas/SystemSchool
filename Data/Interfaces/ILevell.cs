using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILevell
    {

        Levell AddLevel(Levell level);
        List<Levell> GetAllLevels();
        bool UpdateLevel(Levell level);
        Levell GetLevelById(int id);
        bool DeleteLevelById(int id);
        List<Levell> GetLevelByTurn(string turn);
    }
}
