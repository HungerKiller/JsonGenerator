using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonGenerator.Models
{
    public class PopulationOfYear
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("areas_population")]
        public List<PopulationOfArea> AreasPopulation { get; set; }
    }

    public class PopulationOfArea
    {
        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        [JsonProperty("region_name")]
        public string RegionName { get; set; }

        [JsonProperty("together")]
        public PopulationByAge Together { get; set; }

        [JsonProperty("men")]
        public PopulationByAge Men { get; set; }

        [JsonProperty("women")]
        public PopulationByAge Women { get; set; }
    }

    public class PopulationByAge
    {
        [JsonProperty("between0and19")]
        public int Between0and19 { get; set; }

        [JsonProperty("between20and39")]
        public int Between20and39 { get; set; }

        [JsonProperty("between40and59")]
        public int Between40and59 { get; set; }

        [JsonProperty("between60and74")]
        public int Between60and74 { get; set; }

        [JsonProperty("greaterthan75")]
        public int GreaterThan75 { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}