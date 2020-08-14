using System;
namespace EnergyDashboardDatabaseManipulation.TableHelper
{
    public class DBDocType
    {
        /* 
        The database will be organized by energy unit
        kW collection, kWh collection, Condensate collection
        The EnergyType refers to source such as solar
        or chiller (air conditioning). However, most sources
        or types will simply be electric.
        */

        /// <summary>
        /// Gets or Sets building name 
        /// </summary>
        public string? BuildingName { get; set; }

        /// <summary>
        /// Gets or sets energy type
        /// Solar, Electric, etc. 
        /// </summary>
        public string? EnergyType { get; set; }

        /// <summary>
        /// Gets or Sets the energy value
        /// </summary>
        public long? EnergyValue { get; set; }

        /// <summary>
        /// Gets or Sets the time the
        /// EnergyValue was taken
        /// Unix formatted time
        /// </summary>
        public long? UnixTimeValue { get; set; }
    }
}
