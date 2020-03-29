using ComputerStore.Lib.Models.PartTypes.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ComputerStore.Lib.Models
{
    public class PcPart : EntityBase
    {
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PartType Type { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Ean { get; set; }
        
        
        public virtual Maker Maker { get; set; }
        public int MakerId { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
