using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Lib.Models.Parts
{
    public class Cpu : PartBase
    {
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description ")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "CoreCount ")]
        public int CoreCount { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Frequency ")]
        public double Frequency { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "TurboFrequency ")]
        public double TurboFrequency { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Cache ")]
        public double Cache { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "ThreadCount ")]
        public int ThreadCount { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "MicroArchitecture ")]
        public string MicroArchitecture { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Channels ")]
        public int Channels { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "TDP ")]
        public double TDP { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Voltage ")]
        public double Voltage { get; set; }

        [Display(Name = "MemoryType ")]
        [DataType(DataType.Text)]
        public MemoryType MemoryType { get; set; }

    }
}
