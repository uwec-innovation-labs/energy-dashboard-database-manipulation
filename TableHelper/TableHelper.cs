using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace EnergyDashboardDatabaseManipulation.TableHelper
{
    public class TableHelper
    {
        public static List<TableType> GetTables()
        {
            using var stream = typeof(TableHelper).Assembly.GetManifestResourceStream(typeof(TableHelper), "tables.csv");
            if (stream == null)
            {
                throw new System.ArgumentNullException("File not found");
            }
            using (var csv = new CsvReader(new StreamReader(stream), CultureInfo.InvariantCulture))
            {
                var tables = csv.GetRecords<TableType>();
                
                return tables.ToList();
            }
        }
    }
}
