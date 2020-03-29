using ComputerStore.Lib.Models.PcBuilds;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStore.Api.Repositories
{
    public class PcBuildRepository
    {
        private readonly IMongoCollection<PcBuild> PcBuilds;

        public PcBuildRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("PcBuildsDatabase"));
            var database = client.GetDatabase("PcBuildsDb");
            PcBuilds = database.GetCollection<PcBuild>("PcBuilds");
        }

        public PcBuild CreatePcBuild(PcBuild pcBuild)
        {
            // Add creation date
            pcBuild.CreationDate = DateTime.UtcNow;

            // Insert the item in the db            
            PcBuilds.InsertOne(pcBuild);

            // Return the new item (id has been filled in)
            return pcBuild;
        }

        public PcBuild ReadBuildById(string id)
        {
            return PcBuilds.Find<PcBuild>(pcBuild => pcBuild.Id == id).FirstOrDefault();
        }

        public List<PcBuild> ReadBuilds()
        {
            return PcBuilds.Find(i => true).ToList();
        }

        public void DeleteBuildById(string id)
        {
            PcBuilds.DeleteOne(b => b.Id == id);
        }

        public void DeleteBuilds()
        {
            PcBuilds.DeleteMany(Builders<PcBuild>.Filter.Eq("Creator", "CW team"));
        }
    }
}
