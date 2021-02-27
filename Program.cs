using System;

namespace JsonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var dataSet = ExcelReader.ReadRegionPopulations("Resources/estim.pop.nreg.sexe.gca.1975.2021.fr.xls");
            var regionsObjects = Convertor.ConvertRegionDatasetToObject(dataSet);
            JsonWriter.WriteJson(regionsObjects, "populationRegions.json");

            var franceObjects = Convertor.ConvertFranceDatasetToObject(dataSet);
            JsonWriter.WriteJson(franceObjects, "populationFrance.json");
            
        }
    }
}
