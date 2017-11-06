namespace TestTask.Farm6.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Farm : Do
    {
        [Display(Name=nameof(Resources.Models.Farm_Farmer), ResourceType = typeof(Resources.Models))]
        [Required]
        public string Farmer { get; set; }

        [Display(Name = nameof(Resources.Models.Farm_Name), ResourceType = typeof(Resources.Models))]
        [Required]
        public string Name { get; set; }

        [Display(Name = nameof(Resources.Models.Farm_Kultur), ResourceType = typeof(Resources.Models))]
        [Required]
        public string Kultur { get; set; }

        [Display(Name = nameof(Resources.Models.Farm_LastYearHarvest), ResourceType = typeof(Resources.Models))]
        [Required]
        public decimal LastYearHarvest { get; set; }

        [Display(Name = nameof(Resources.Models.Farm_Area), ResourceType = typeof(Resources.Models))]
        [Required]
        public decimal Area { get; set; }

        public double? GisX { get; set; }

        public double? GisY { get; set; }

        [Display(Name = nameof(Resources.Models.Farm_Region), ResourceType = typeof(Resources.Models))]
        [Required]
        public string Region { get; set; }

        public Farm() { }

        public Farm(string farmer, string name, string kultur, decimal lastYearHarvest, decimal area, double gisX, double gisY, string region)
        {
            Farmer = farmer;
            Name = name;
            Kultur = kultur;
            LastYearHarvest = lastYearHarvest;
            Area = area;
            GisX = gisX;
            GisY = gisY;
            Region = region;
        }
    }
}