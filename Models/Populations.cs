using System.Collections.Generic;

namespace JsonGenerator.Models
{
    public class PopulationOfYear
    {
        public int Year { get; set; }

        public List<PopulationOfArea> AreasPopulation { get; set; }
    }

    public class PopulationOfArea
    {
        public string AreaCode { get; set; }

        public string AreaName { get; set; }

        public PopulationByAge Together { get; set; }

        public PopulationByAge Men { get; set; }

        public PopulationByAge Women { get; set; }
    }

    public class PopulationByAge
    {
        public int Between0and19 { get; set; }

        public int Between20and39 { get; set; }

        public int Between40and59 { get; set; }

        public int Between60and74 { get; set; }

        public int GreaterThan75 { get; set; }

        public int Total { get; set; }
    }
}