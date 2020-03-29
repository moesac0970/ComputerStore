using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ComputerStore.Lib.Models.PcBuilds
{
    public class PcBuild
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("CreationDate")]
        public DateTime CreationDate { get; set; }

        [BsonElement("PcParts")]
        public IEnumerable<PcPart> PcParts { get; set; }
    }
}
