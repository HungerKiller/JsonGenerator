using ExcelDataReader;
using System.Data;
using System.IO;

namespace JsonGenerator
{
    public class ExcelReader
    {
        public static DataSet ReadRegionPopulations(string filePath)
        {
            DataSet dataSet = null;
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                        }
                    } while (reader.NextResult());

                    // Use the AsDataSet extension method
                    dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    // The result of each spreadsheet is in result.Tables
                }
            }
            return dataSet;
        }
    }
}
