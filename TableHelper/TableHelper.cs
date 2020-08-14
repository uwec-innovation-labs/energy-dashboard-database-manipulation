using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace EnergyDashboardDatabaseManipulation.TableHelper
{
    public class TableHelper
    {
        public List<TableType> GetTables()
        {
            using (var reader = new StreamReader("tables.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var tables = csv.GetRecords<TableType>();
                
                return tables.ToList();
            }
        }
    }
}
