using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.Parts;
using ComputerStore.Lib.Models.PartTypes.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;

namespace ComputerStore.Api.Data
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maker>().ToTable("Makers").HasData(
                new Maker { Id = 1, CreationDate = DateTime.Now, Name = "Nvidia" },
                new Maker { Id = 2, CreationDate = DateTime.Now, Name = "Intel" },
                new Maker { Id = 3, CreationDate = DateTime.Now, Name = "AMD" },
                new Maker { Id = 4, CreationDate = DateTime.Now, Name = "Radeon" },
                new Maker { Id = 5, CreationDate = DateTime.Now, Name = "Logitech" },
                new Maker { Id = 6, CreationDate = DateTime.Now, Name = "Razer" },
                new Maker { Id = 7, CreationDate = DateTime.Now, Name = "GigaByte" },
                new Maker { Id = 8, CreationDate = DateTime.Now, Name = "Segate" },
                new Maker { Id = 9, CreationDate = DateTime.Now, Name = "Msi" },
                new Maker { Id = 10, CreationDate = DateTime.Now, Name = "ThermalTake" },
                new Maker { Id = 11, CreationDate = DateTime.Now, Name = "WD" },
                new Maker { Id = 12, CreationDate = DateTime.Now, Name = "Corsair" },
                new Maker { Id = 13, CreationDate = DateTime.Now, Name = "Sandisk" },
                new Maker { Id = 14, CreationDate = DateTime.Now, Name = "Asus" },
                new Maker { Id = 15, CreationDate = DateTime.Now, Name = "Cougar" },
                new Maker { Id = 16, CreationDate = DateTime.Now, Name = "Ldlc" }
                ); ;

            modelBuilder.Entity<OrderItem>().ToTable("OrderItems").HasData(
                new { Id = 1, CreationDate = DateTime.Now, OrderId = 1, IsDelivered = false, pcPartsId = 1, Quantity = 4 },
                new { Id = 2, CreationDate = DateTime.Now, OrderId = 1, IsDelivered = false, pcPartsId = 2, Quantity = 4 });

            modelBuilder.Entity<Order>().ToTable("Orders").HasData(
                new { Id = 1, CreationDate = DateTime.Now, OrderItemId = 1 }
                );

            modelBuilder.Entity<PcPart>().ToTable("PcParts").HasData(
                new { Id = 1, CreationDate = DateTime.Now, MakerId = 1, Ean = "131653135165133", Name = "GeForce GTX 1660 Ti", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Gpu },
                new { Id = 2, CreationDate = DateTime.Now, MakerId = 11, Ean = "321365646561231", Name = "wd blue sn500gb nvme ssd", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 3, CreationDate = DateTime.Now, MakerId = 8, Ean = "232235846323225", Name = "Segate SSD500GB", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 4, CreationDate = DateTime.Now, MakerId = 3, Ean = "321365646561231", Name = "amd ryzen 5", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Cpu },
                new { Id = 5, CreationDate = DateTime.Now, MakerId = 3, Ean = "321365646561231", Name = "amd ryzen 7", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Cpu },
                new { Id = 6, CreationDate = DateTime.Now, MakerId = 3, Ean = "321365646561231", Name = "amd ryzen 9", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Cpu },
                new { Id = 7, CreationDate = DateTime.Now, MakerId = 14, Ean = "321365646561231", Name = "asus gaming", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.MotherBoard },
                new { Id = 8, CreationDate = DateTime.Now, MakerId = 14, Ean = "321365646561231", Name = "asus rog strix", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.MotherBoard },
                new { Id = 9, CreationDate = DateTime.Now, MakerId = 14, Ean = "321365646561231", Name = "asus rog strix helios", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.PcCase },
                new { Id = 10, CreationDate = DateTime.Now, MakerId = 12, Ean = "321365646561231", Name = "Cougar conquer atx gaming", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.PcCase },
                new { Id = 11, CreationDate = DateTime.Now, MakerId = 7, Ean = "321365646561231", Name = "gigabyte md80", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.MotherBoard },
                new { Id = 12, CreationDate = DateTime.Now, MakerId = 7, Ean = "321365646561231", Name = "gigabyte x570", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.MotherBoard },
                new { Id = 13, CreationDate = DateTime.Now, MakerId = 2, Ean = "321365646561231", Name = "intel core pentium", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Cpu },
                new { Id = 14, CreationDate = DateTime.Now, MakerId = 2, Ean = "321365646561231", Name = "intel i5", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Cpu },
                new { Id = 15, CreationDate = DateTime.Now, MakerId = 2, Ean = "321365646561231", Name = "intel i7", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Cpu },
                new { Id = 16, CreationDate = DateTime.Now, MakerId = 2, Ean = "321365646561231", Name = "intel i9", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Cpu },
                new { Id = 17, CreationDate = DateTime.Now, MakerId = 2, Ean = "321365646561231", Name = "intel server motherbaord", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.MotherBoard },
                new { Id = 18, CreationDate = DateTime.Now, MakerId = 15, Ean = "321365646561231", Name = "Ldlc ssd pcie nvme", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 19, CreationDate = DateTime.Now, MakerId = 9, Ean = "321365646561231", Name = "msi b450 gaming", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.MotherBoard },
                new { Id = 20, CreationDate = DateTime.Now, MakerId = 13, Ean = "321365646561231", Name = "sandisk sdcard 1tb", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 21, CreationDate = DateTime.Now, MakerId = 8, Ean = "321365646561231", Name = "seagate barracuda 5tb", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 22, CreationDate = DateTime.Now, MakerId = 8, Ean = "321365646561231", Name = "seagate barracuda 8tb", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 23, CreationDate = DateTime.Now, MakerId = 8, Ean = "321365646561231", Name = "seagate barracuda ssd 510gb", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 24, CreationDate = DateTime.Now, MakerId = 8, Ean = "321365646561231", Name = "seagate nightghawk 8tb", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 25, CreationDate = DateTime.Now, MakerId = 10, Ean = "321365646561231", Name = "thermaltake core3 g3 ", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.PcCase },
                new { Id = 26, CreationDate = DateTime.Now, MakerId = 11, Ean = "321365646561231", Name = "wd blue 1tb", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 27, CreationDate = DateTime.Now, MakerId = 11, Ean = "321365646561231", Name = "wd red nas hdd 2tb", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Memory },
                new { Id = 28, CreationDate = DateTime.Now, MakerId = 12, Ean = "321365646561231", Name = "corsair carbide spec omega", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.PcCase },
                new { Id = 29, CreationDate = DateTime.Now, MakerId = 3, Ean = "321365646561231", Name = "gtx 1050ti", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Gpu },
                new { Id = 30, CreationDate = DateTime.Now, MakerId = 1, Ean = "321365646561231", Name = "geforce gtx 1070", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Gpu },
                new { Id = 31, CreationDate = DateTime.Now, MakerId = 1, Ean = "321365646561231", Name = "geforce rtx 2080ti ", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Gpu },
                new { Id = 32, CreationDate = DateTime.Now, MakerId = 3, Ean = "321365646561231", Name = "amd vega 11", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Gpu },
                new { Id = 33, CreationDate = DateTime.Now, MakerId = 3, Ean = "321365646561231", Name = "amd radeon rx5700", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Gpu },
                new { Id = 34, CreationDate = DateTime.Now, MakerId = 3, Ean = "321365646561231", Name = "radeon rx 5600xt", Price = 100.0, ReleaseDate = DateTime.Now, Type = PartType.Gpu }
               );

            modelBuilder.Entity<Image>().ToTable("Images").HasData(
                new { Id = 1, CreationDate = DateTime.Now, FileName = "amd_ryzen_5.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 4 },
                new { Id = 2, CreationDate = DateTime.Now, FileName = "amd_ryzen_7.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 5 },
                new { Id = 3, CreationDate = DateTime.Now, FileName = "AMD-Ryzen-9-3950X.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 6 },
                new { Id = 4, CreationDate = DateTime.Now, FileName = "asus_gaming.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 7 },
                new { Id = 5, CreationDate = DateTime.Now, FileName = "asus_rog_strix.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 8 },
                new { Id = 6, CreationDate = DateTime.Now, FileName = "ASUS_ROG_Strix_Helios.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 9 },
                new { Id = 7, CreationDate = DateTime.Now, FileName = "Corsair_carbide_spec_omega.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 28 },
                new { Id = 8, CreationDate = DateTime.Now, FileName = "Cougar_conquer_atx_gaming.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 10 },
                new { Id = 9, CreationDate = DateTime.Now, FileName = "gigabyte_MD80.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 11 },
                new { Id = 12, CreationDate = DateTime.Now, FileName = "intel_i5.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 14 },
                new { Id = 13, CreationDate = DateTime.Now, FileName = "intel_i7.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 15 },
                new { Id = 14, CreationDate = DateTime.Now, FileName = "intel_i9.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 16 },
                new { Id = 15, CreationDate = DateTime.Now, FileName = "intel_server_motherboard.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 17 },
                new { Id = 16, CreationDate = DateTime.Now, FileName = "ldlc_ssd_pcienvme_240.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 18 },
                new { Id = 17, CreationDate = DateTime.Now, FileName = "Msi_b450_gaming.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 19 },
                new { Id = 18, CreationDate = DateTime.Now, FileName = "sandisk_sdcard_1tb.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 20 },
                new { Id = 19, CreationDate = DateTime.Now, FileName = "seagate_barracuda_5tb.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 21 },
                new { Id = 20, CreationDate = DateTime.Now, FileName = "Seagate_barracuda_8tb.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 22 },
                new { Id = 21, CreationDate = DateTime.Now, FileName = "seagate_barracuda_ssd_510.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 23 },
                new { Id = 22, CreationDate = DateTime.Now, FileName = "seagate_nighthawk_8tb.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 24 },
                new { Id = 23, CreationDate = DateTime.Now, FileName = "thermaltake_core3_g3.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 25 },
                new { Id = 24, CreationDate = DateTime.Now, FileName = "wd_blue_1tb.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 26 },
                new { Id = 25, CreationDate = DateTime.Now, FileName = "wd_red_nas_hdd_2tb.jpg", Parttype = PartType.Memory, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 27 },
                new { Id = 26, CreationDate = DateTime.Now, FileName = "amd_vega_11.jpg", Parttype = PartType.Gpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 32 },
                new { Id = 27, CreationDate = DateTime.Now, FileName = "amd-radeon-rx-5700.jpg", Parttype = PartType.Gpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 33 },
                new { Id = 28, CreationDate = DateTime.Now, FileName = "geforce_gtx_1070_founder.jpg", Parttype = PartType.Gpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 30 },
                new { Id = 29, CreationDate = DateTime.Now, FileName = "geforce_rtx_2080ti_11gb.jpg", Parttype = PartType.Gpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 31 },
                new { Id = 30, CreationDate = DateTime.Now, FileName = "gtx_1660ti.jpg", Parttype = PartType.Gpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 1 },
                new { Id = 31, CreationDate = DateTime.Now, FileName = "Gtx-1050Ti.jpg", Parttype = PartType.Gpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 29 },
                new { Id = 32, CreationDate = DateTime.Now, FileName = "radeon-rx-5600xt.jpg", Parttype = PartType.Gpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 34 },
                new { Id = 33, CreationDate = DateTime.Now, FileName = "intel_core_pentium.jpg", Parttype = PartType.Cpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 13 },
                new { Id = 34, CreationDate = DateTime.Now, FileName = "wd_blue_nvme_ssd_500.jpg", Parttype = PartType.Cpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 2 },
                new { Id = 35, CreationDate = DateTime.Now, FileName = "Seagate_BarraCuda_SSD__500_GB.jpg", Parttype = PartType.Cpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 3 },
                new { Id = 36, CreationDate = DateTime.Now, FileName = "gigabyte_x570.jpg", Parttype = PartType.Cpu, Type = "image/jpeg", WeightMb = 1.3, PcPartId = 12 }
                );

            modelBuilder.Entity<Gpu>().ToTable("Gpus").HasData(
               new { Id = 1, PcPartId = 1, PowerUsage = 105.6, Memory = 8.0, MemoryType = MemoryType.GDDR5, CreationDate = DateTime.Now, Frequency = 1500.0, BoostFrequency = 1770.0, Description = "nvdia GeForce GTX 1660 Ti, good for gaming and video editing up to 4K", Os = $"{Os.linux}, {Os.windows10}, {Os.windows7}, {Os.windows8}", Connection = "PCIe x16 Versie 3.0", Ports = "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4" },
               new { Id = 2, PcPartId = 30, PowerUsage = 105.6, Memory = 8.0, MemoryType = MemoryType.GDDR5, CreationDate = DateTime.Now, Frequency = 1500.0, BoostFrequency = 1770.0, Description = "nvdia GeForce GTX 1070 founders edition, good for gaming and video editing up to 4K", Os = $"{Os.linux}, {Os.windows10}, {Os.windows7}, {Os.windows8}", Connection = "PCIe x16 Versie 3.0", Ports = "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4" },
               new { Id = 3, PcPartId = 31, PowerUsage = 105.6, Memory = 8.0, MemoryType = MemoryType.GDDR5, CreationDate = DateTime.Now, Frequency = 1500.0, BoostFrequency = 1770.0, Description = "nvdia GeForce rtx 2080ti, good for gaming and video editing up to 4K", Os = $"{Os.linux}, {Os.windows10}, {Os.windows7}, {Os.windows8}", Connection = "PCIe x16 Versie 3.0", Ports = "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4" },
               new { Id = 4, PcPartId = 32, PowerUsage = 105.6, Memory = 8.0, MemoryType = MemoryType.GDDR5, CreationDate = DateTime.Now, Frequency = 1500.0, BoostFrequency = 1770.0, Description = "amd vega 11, good for gaming and video editing up to 4K", Os = $"{Os.linux}, {Os.windows10}, {Os.windows7}, {Os.windows8}", Connection = "PCIe x16 Versie 3.0", Ports = "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4" },
               new { Id = 5, PcPartId = 33, PowerUsage = 105.6, Memory = 8.0, MemoryType = MemoryType.GDDR5, CreationDate = DateTime.Now, Frequency = 1500.0, BoostFrequency = 1770.0, Description = "amd radeon tx 5600xt, good for gaming and video editing up to 4K", Os = $"{Os.linux}, {Os.windows10}, {Os.windows7}, {Os.windows8}", Connection = "PCIe x16 Versie 3.0", Ports = "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4" },
               new { Id = 6, PcPartId = 34, PowerUsage = 105.6, Memory = 8.0, MemoryType = MemoryType.GDDR5, CreationDate = DateTime.Now, Frequency = 1500.0, BoostFrequency = 1770.0, Description = "radeon rx 5600xt, good for gaming and video editing up to 4K", Os = $"{Os.linux}, {Os.windows10}, {Os.windows7}, {Os.windows8}", Connection = "PCIe x16 Versie 3.0", Ports = "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4" },
               new { Id = 7, PcPartId = 29, PowerUsage = 105.6, Memory = 8.0, MemoryType = MemoryType.GDDR5, CreationDate = DateTime.Now, Frequency = 1500.0, BoostFrequency = 1770.0, Description = "gtx 1050ti, good for gaming and video editing up to 4K", Os = $"{Os.linux}, {Os.windows10}, {Os.windows7}, {Os.windows8}", Connection = "PCIe x16 Versie 3.0", Ports = "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4" }
               );

            modelBuilder.Entity<Cpu>().ToTable("Cpus").HasData(
                new { Id = 1, PcPartId = 4, CoreCount = 4, Channels = 6, MemoryType = MemoryType.GDDR6, CreationDate = DateTime.Now, Frequency = 2.8, MakerId = 2, Voltage = 100.0, Cache = 8.0, TurboFrequency = 3.6, ThreadCount = 8, MicroArchitecture = "Kaby lake", TDP = 70.0 },
                new { Id = 2, PcPartId = 5, CoreCount = 4, Channels = 6, MemoryType = MemoryType.GDDR6, CreationDate = DateTime.Now, Frequency = 2.8, MakerId = 2, Voltage = 100.0, Cache = 8.0, TurboFrequency = 3.6, ThreadCount = 8, MicroArchitecture = "Kaby lake", TDP = 70.0 },
                new { Id = 3, PcPartId = 6, CoreCount = 4, Channels = 6, MemoryType = MemoryType.GDDR6, CreationDate = DateTime.Now, Frequency = 2.8, MakerId = 2, Voltage = 100.0, Cache = 8.0, TurboFrequency = 3.6, ThreadCount = 8, MicroArchitecture = "Kaby lake", TDP = 70.0 },
                new { Id = 4, PcPartId = 13, CoreCount = 4, Channels = 6, MemoryType = MemoryType.GDDR6, CreationDate = DateTime.Now, Frequency = 2.8, MakerId = 2, Voltage = 100.0, Cache = 8.0, TurboFrequency = 3.6, ThreadCount = 8, MicroArchitecture = "Kaby lake", TDP = 70.0 },
                new { Id = 5, PcPartId = 14, CoreCount = 4, Channels = 6, MemoryType = MemoryType.GDDR6, CreationDate = DateTime.Now, Frequency = 2.8, MakerId = 2, Voltage = 100.0, Cache = 8.0, TurboFrequency = 3.6, ThreadCount = 8, MicroArchitecture = "Kaby lake", TDP = 70.0 },
                new { Id = 6, PcPartId = 15, CoreCount = 4, Channels = 6, MemoryType = MemoryType.GDDR6, CreationDate = DateTime.Now, Frequency = 2.8, MakerId = 2, Voltage = 100.0, Cache = 8.0, TurboFrequency = 3.6, ThreadCount = 8, MicroArchitecture = "Kaby lake", TDP = 70.0 },
                new { Id = 7, PcPartId = 16, CoreCount = 4, Channels = 6, MemoryType = MemoryType.GDDR6, CreationDate = DateTime.Now, Frequency = 2.8, MakerId = 2, Voltage = 100.0, Cache = 8.0, TurboFrequency = 3.6, ThreadCount = 8, MicroArchitecture = "Kaby lake", TDP = 70.0 }
                );

            modelBuilder.Entity<Memory>().ToTable("Memory").HasData(
                new Memory { Id = 1, PcPartId = 2, Capacity = 500.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.0 },
                new Memory { Id = 2, PcPartId = 3, Capacity = 500.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.0 },
                new Memory { Id = 3, PcPartId = 18, Capacity = 500.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.0 },
                new Memory { Id = 4, PcPartId = 20, Capacity = 1000.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.013 },
                new Memory { Id = 5, PcPartId = 21, Capacity = 5000.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.08 },
                new Memory { Id = 6, PcPartId = 22, Capacity = 8000.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.08 },
                new Memory { Id = 7, PcPartId = 23, Capacity = 500.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.0 },
                new Memory { Id = 8, PcPartId = 24, Capacity = 8000.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.08 },
                new Memory { Id = 9, PcPartId = 26, Capacity = 1000.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.011 },
                new Memory { Id = 10, PcPartId = 27, Capacity = 2000.0, CreationDate = DateTime.Now, PowerUsage = 50.0, Weight = 100.0, Cache = 8.0, Speed = 200.0 }
                );

            modelBuilder.Entity<MotherBoard>().ToTable("MotherBoards").HasData(
                new MotherBoard { Id = 1, PcPartId = 7, Chipset = "something", CreationDate = DateTime.Now, Inputs = "pcie", Usage = "pc", MaxMemory = 128.5, SupportedMemoryType = MemoryType.GDDR6, MemorySlotCount = 6, BiosType = "Uefi" },
                new MotherBoard { Id = 2, PcPartId = 8, Chipset = "something", CreationDate = DateTime.Now, Inputs = "pcie", Usage = "pc", MaxMemory = 128.5, SupportedMemoryType = MemoryType.GDDR6, MemorySlotCount = 6, BiosType = "Uefi" },
                new MotherBoard { Id = 3, PcPartId = 11, Chipset = "something", CreationDate = DateTime.Now, Inputs = "pcie", Usage = "pc", MaxMemory = 128.5, SupportedMemoryType = MemoryType.GDDR6, MemorySlotCount = 6, BiosType = "Uefi" },
                new MotherBoard { Id = 4, PcPartId = 12, Chipset = "something", CreationDate = DateTime.Now, Inputs = "pcie", Usage = "pc", MaxMemory = 128.5, SupportedMemoryType = MemoryType.GDDR6, MemorySlotCount = 6, BiosType = "Uefi" },
                new MotherBoard { Id = 5, PcPartId = 17, Chipset = "something", CreationDate = DateTime.Now, Inputs = "pcie", Usage = "pc", MaxMemory = 128.5, SupportedMemoryType = MemoryType.GDDR6, MemorySlotCount = 6, BiosType = "Uefi" },
                new MotherBoard { Id = 6, PcPartId = 19, Chipset = "something", CreationDate = DateTime.Now, Inputs = "pcie", Usage = "pc", MaxMemory = 128.5, SupportedMemoryType = MemoryType.GDDR6, MemorySlotCount = 6, BiosType = "Uefi" }
              );

            modelBuilder.Entity<PcCase>().ToTable("PcCases").HasData(
               new { Id = 1, PcPartId = 9, Color = "black", Materials = "aluminium", InternalDimentions = "100,30,30", Dimentions = "100,30,30", Description = "newest case from asus ", CreationDate = DateTime.Now },
               new { Id = 2, PcPartId = 25, Color = "black", Materials = "aluminium", InternalDimentions = "100,30,30", Dimentions = "100,30,30", Description = "newest case from thermaltake ", CreationDate = DateTime.Now },
               new { Id = 3, PcPartId = 10, Color = "black", Materials = "aluminium", InternalDimentions = "100,30,30", Dimentions = "100,30,30", Description = "newest case from cougar", CreationDate = DateTime.Now },
               new { Id = 4, PcPartId = 28, Color = "black", Materials = "aluminium", InternalDimentions = "100,30,30", Dimentions = "100,30,30", Description = "newest case from corsair", CreationDate = DateTime.Now }
               );

        }
    }
}
