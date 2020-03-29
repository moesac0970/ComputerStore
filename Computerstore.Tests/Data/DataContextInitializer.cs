using ComputerStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computerstore.Tests.Data
{
    public class DataContextInitializer
    {

        public static void Initialize(DataContext context)
        {
            if (context.PcParts.Any() || context.Orders.Any() || context.MotherBoards.Any() || 
                context.Makers.Any() || context.Memories.Any() || context.Images.Any() ||
                context.Cpus.Any() || context.Gpus.Any())
            {
                return;
            }

            SeedInmemoryDatabase(context);
        }


        private static void SeedInmemoryDatabase(DataContext context)
        {

            context.PcParts.AddRange(MockData.ListOfPcParts);
            context.Images.AddRange(MockData.ListOfImages);
            context.Makers.AddRange(MockData.ListOfMakers);
            context.MotherBoards.AddRange(MockData.MotherBoards);
            context.Memories.AddRange(MockData.Memories);
            context.PcCases.AddRange(MockData.PcCases);
            context.Cpus.AddRange(MockData.Cpus);
            context.Gpus.AddRange(MockData.Gpus);


            context.SaveChanges();
        }
    }
}
