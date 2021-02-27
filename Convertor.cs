using JsonGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace JsonGenerator
{
    public class Convertor
    {
        public static List<PopulationOfYear> ConvertRegionDatasetToObject(DataSet dataSet)
        {
            var populationOfYears = new List<PopulationOfYear>();

            for (var i = dataSet.Tables.Count - 1; i >= 0; i--)
            {
                if (!int.TryParse(dataSet.Tables[i].TableName.Trim(), out int year))
                    continue;
                // Get datas
                var areasPopulation = new List<PopulationOfArea>();
                for (var j = 0; j < dataSet.Tables[i].Rows.Count; j++)
                {
                    switch (dataSet.Tables[i].Rows[j].ItemArray[0].ToString().Trim())
                    {
                        case "Auvergne-Rhône-Alpes":
                            areasPopulation.Add(ConvertDatas("FR-ARA", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Bourgogne-Franche-Comté":
                            areasPopulation.Add(ConvertDatas("FR-BFC", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Bretagne":
                            areasPopulation.Add(ConvertDatas("FR-BRE", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Centre-Val-de-Loire":
                            areasPopulation.Add(ConvertDatas("FR-CVL", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Corse":
                            areasPopulation.Add(ConvertDatas("FR-COR", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Grand Est":
                            areasPopulation.Add(ConvertDatas("FR-GES", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Hauts-de-France":
                            areasPopulation.Add(ConvertDatas("FR-HDF", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Île-de-France":
                            areasPopulation.Add(ConvertDatas("FR-IDF", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Normandie":
                            areasPopulation.Add(ConvertDatas("FR-NOR", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Nouvelle-Aquitaine":
                            areasPopulation.Add(ConvertDatas("FR-NAQ", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Occitanie":
                            areasPopulation.Add(ConvertDatas("FR-OCC", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Pays de la Loire":
                            areasPopulation.Add(ConvertDatas("FR-PDL", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Provence-Alpes-Côte d'Azur":
                            areasPopulation.Add(ConvertDatas("FR-PAC", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Guadeloupe":
                            areasPopulation.Add(ConvertDatas("FR-GUA", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Martinique":
                            areasPopulation.Add(ConvertDatas("FR-MTQ", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Guyane":
                            areasPopulation.Add(ConvertDatas("FR-GUF", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "La Réunion":
                            areasPopulation.Add(ConvertDatas("FR-LRE", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "Mayotte":
                            areasPopulation.Add(ConvertDatas("FR-MAY", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        default:
                            break;
                    }
                }
                populationOfYears.Add(new PopulationOfYear { Year = year, AreasPopulation = areasPopulation });
            }
            return populationOfYears;
        }

        public static List<PopulationOfYear> ConvertFranceDatasetToObject(DataSet dataSet)
        {
            var populationOfYears = new List<PopulationOfYear>();

            for (var i = dataSet.Tables.Count - 1; i >= 0; i--)
            {
                if (!int.TryParse(dataSet.Tables[i].TableName.Trim(), out int year))
                    continue;
                // Get datas
                var areasPopulation = new List<PopulationOfArea>();
                for (var j = 0; j < dataSet.Tables[i].Rows.Count; j++)
                {
                    switch (dataSet.Tables[i].Rows[j].ItemArray[0].ToString().Trim())
                    {
                        case "France métropolitaine":
                            areasPopulation.Add(ConvertDatas("Métropole", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "DOM":
                            areasPopulation.Add(ConvertDatas("DOM", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        case "France métropolitaine et DOM":
                            areasPopulation.Add(ConvertDatas("France", dataSet.Tables[i].Rows[j].ItemArray));
                            break;
                        default:
                            break;
                    }
                }
                populationOfYears.Add(new PopulationOfYear { Year = year, AreasPopulation = areasPopulation });
            }
            return populationOfYears;
        }

        private static PopulationOfArea ConvertDatas(string code, object[] itemArray)
        {
            try
            {
                var together = new PopulationByAge
                {
                    Between0and19 = int.Parse(itemArray[1].ToString().Trim()),
                    Between20and39 = int.Parse(itemArray[2].ToString().Trim()),
                    Between40and59 = int.Parse(itemArray[3].ToString().Trim()),
                    Between60and74 = int.Parse(itemArray[4].ToString().Trim()),
                    GreaterThan75 = int.Parse(itemArray[5].ToString().Trim()),
                    Total = int.Parse(itemArray[6].ToString().Trim())
                };
                var men = new PopulationByAge
                {
                    Between0and19 = int.Parse(itemArray[7].ToString().Trim()),
                    Between20and39 = int.Parse(itemArray[8].ToString().Trim()),
                    Between40and59 = int.Parse(itemArray[9].ToString().Trim()),
                    Between60and74 = int.Parse(itemArray[10].ToString().Trim()),
                    GreaterThan75 = int.Parse(itemArray[11].ToString().Trim()),
                    Total = int.Parse(itemArray[12].ToString().Trim())
                };
                var women = new PopulationByAge
                {
                    Between0and19 = int.Parse(itemArray[13].ToString().Trim()),
                    Between20and39 = int.Parse(itemArray[14].ToString().Trim()),
                    Between40and59 = int.Parse(itemArray[15].ToString().Trim()),
                    Between60and74 = int.Parse(itemArray[16].ToString().Trim()),
                    GreaterThan75 = int.Parse(itemArray[17].ToString().Trim()),
                    Total = int.Parse(itemArray[18].ToString().Trim())
                };

                return new PopulationOfArea
                {
                    RegionCode = code,
                    RegionName = itemArray[0].ToString().Trim(),
                    Together = together,
                    Men = men,
                    Women = women
                };
            }
            catch
            {
                throw new Exception($"Error in sheet : {itemArray[0]}");
            }
        }
    }
}
