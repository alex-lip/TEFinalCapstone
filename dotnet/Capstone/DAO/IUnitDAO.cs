using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IUnitDAO
    {
        List<Unit> GetUnits();

        Unit GetUnitById(int unit_id);

        void DeleteUnit(Unit unit);

        bool AddUnit(Unit unit);

        bool EditUnit(int id, Unit unit);
    }
}
