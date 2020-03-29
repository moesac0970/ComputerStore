using AutoMapper;
using AutoMapper.QueryableExtensions;
using ComputerStore.Api.Services;
using ComputerStore.Data;
using ComputerStore.Lib.Dto;
using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.Parts;
using ComputerStore.Lib.Models.PartTypes.Enumerations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Api.Repositories
{
    public class PcPartRepository : MappingRepository<PcPart>
    {
        public PcPartRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<List<PcPartBasic>> GetPartsBasic()
        {
            return db.PcParts
                .ProjectTo<PcPartBasic>(mapper.ConfigurationProvider)
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public async Task<PcPartBasic> GetPartsBasicById(int id)
        {
            var part = await GetById(id);
            PcPartBasic result = mapper.Map<PcPart, PcPartBasic>(part);
            return result;
        }

        public override async Task<PcPart> GetById(int id)
        {
            return await db.PcParts.Where(p => p.Id == id)
                .Include(p => p.Images)
                .Include(p => p.Maker)
                .FirstOrDefaultAsync();
        }

        public async Task<IPcPart> GetPartById(int id)
        {
            PcPart result = await GetById(id);

            switch (result.Type)
            {
                case PartType.Cpu:
                    return await db.Cpus.Where(p => p.PcPart.Id == id).FirstOrDefaultAsync() ?? new Cpu { PcPart = result };
                case PartType.Gpu:
                    return await db.Gpus.Where(p => p.PcPart.Id == id).FirstOrDefaultAsync() ?? new Gpu { PcPart = result };
                case PartType.Memory:
                    return await db.Memories.Where(p => p.PcPart.Id == id).FirstOrDefaultAsync() ?? new Memory { PcPart = result };
                case PartType.MotherBoard:
                    return await db.MotherBoards.Where(p => p.PcPart.Id == id).FirstOrDefaultAsync() ?? new MotherBoard { PcPart = result };
                case PartType.PcCase:
                    return await db.PcCases.Where(p => p.PcPart.Id == id).FirstOrDefaultAsync() ?? new PcCase { PcPart = result };
                default:
                    break;
            }
            return new Gpu();
        }


        public override IQueryable<PcPart> GetAll()
        {
            return base.GetAll()
                .Include(p => p.Maker)
                .Include(p => p.Images);
        }

        public Image GetImagePathByName(string fileName)
        {
            return db.Images
                .Where(i => i.FileName == fileName)
                .FirstOrDefault();
        }

        public async Task<Image> CreateImage(IFormFile file, int partid)
        {
            var currentPart = await GetById(partid);
            var newImage = new Image
            {
                CreationDate = DateTime.UtcNow,
                FileName = file.FileName,
                PcPart = currentPart,
                Type = file.ContentType,
                WeightMb = ValueConversionService.ConvertBytesToMegabytes(file.Length),
                Parttype = currentPart.Type
            };
             db.Images.AddRange(newImage);

            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            return newImage;
        }


        public async Task<List<PcPart>> GetAllByCategoryName(string categoryName)
        {
            return await db.PcParts
                .Where(p => p.Type.ToString().ToLower() == categoryName.ToLower())
                .ToListAsync();
        }


        public override async Task<PcPart> Delete(int id)
        {
            var pcpart = await GetById(id);

            foreach (var image in pcpart.Images)
            {
                db.Images.Remove(image);
            }

            await db.SaveChangesAsync();

            switch (pcpart.Type)
            {
                case PartType.Cpu:
                    var cpuToDelete = await db.Cpus.Where(c => c.PcPartId == pcpart.Id).FirstOrDefaultAsync();
                    db.Cpus.Remove(cpuToDelete);
                    break;
                case PartType.Gpu:
                    var gpuToDelete = await db.Gpus.Where(c => c.PcPartId == pcpart.Id).FirstOrDefaultAsync();
                    db.Gpus.Remove(gpuToDelete);
                    break;
                case PartType.Memory:
                    var memoryToDelete = await db.Memories.Where(c => c.PcPartId == pcpart.Id).FirstOrDefaultAsync();
                    db.Memories.Remove(memoryToDelete);
                    break;
                case PartType.MotherBoard:
                    var motherboardToDelete = await db.MotherBoards.Where(c => c.PcPartId == pcpart.Id).FirstOrDefaultAsync();
                    db.MotherBoards.Remove(motherboardToDelete);
                    break;
                case PartType.PcCase:
                    var pcCaseToDelete = await db.PcCases.Where(c => c.PcPartId == pcpart.Id).FirstOrDefaultAsync();
                    db.PcCases.Remove(pcCaseToDelete);
                    break;
                default:
                    break;
            }

            await db.SaveChangesAsync();

            db.PcParts.Remove(pcpart);

            await db.SaveChangesAsync();

            return await Task.FromResult(pcpart);
        }
    }
}
