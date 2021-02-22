using System;

namespace JsonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var dataSet = ExcelReader.ReadRegionPopulations("Resources/estim.pop.nreg.sexe.gca.1975.2021.fr.xls");
            var objects = Convertor.ConvertRegionDatasetToObject(dataSet);
            JsonWriter.WriteJson(objects, "populationRegions.json");
        }
    }
}
