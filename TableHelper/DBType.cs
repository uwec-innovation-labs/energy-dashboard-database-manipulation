using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyDashboardDatabaseManipulation.TableHelper
{
    public class DBType
    {
        public string? BuildingName { get; set; }

        public string? EnergyType { get; set; }

        public string? EnergyUnit { get; set; }

        public float? EnergyValue { get; set; }

        public int? UnixTimeValue { get; set; }
    }
}
