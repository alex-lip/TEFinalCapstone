﻿using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IUnitDAO
    {
        List<Unit> GetUnits();
    }
}