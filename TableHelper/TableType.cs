using System;
namespace EnergyDashboardDatabaseManipulation.TableHelper
{ 
    public class TableType
    {
        /// <summary>
        /// Gets or Sets table name
        /// </summary>
        public string? TableName { get; set; }

        /// <summary>
        /// Gets or Sets building name 
        /// </summary>
        public string? BuildingName { get; set; }

        /// <summary>
        /// Gets or sets energy type
        /// </summary>
        public string? EnergyType { get; set; }

        /// <summary>
        /// Gets or Sets energy unit 
        /// </summary>
        public string? EnergyUnit { get; set; }

        /// <summary>
        /// Gets or Sets the report interval
        /// </summary>
        public int? ReportInterval { get; set; }
    }

}
