using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.PartTypes.Enumerations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PcPartsController : ControllerCrudBase<PcPart, PcPartRepository>
    {
        string[] categories;
        string imageDirectoryPath;

        public PcPartsController(PcPartRepository pcPartRepository) : base(pcPartRepository)
        {
            categories = System.Enum.GetNames(typeof(PartType));
            imageDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images/pcparts/");
        }

        [HttpGet]
        [Route("Categories")]
        public IActionResult Categories()
        {
            return Ok(categories);
        }

        [HttpGet]
        [Route("Category/{categoryName}")]
        public async Task<IActionResult> CategoryByName(string categoryName)
        {
            categories = Array.ConvertAll(categories, s => s.ToLower());
            if (!categories.Contains(categoryName.ToLower()))
            {
                return BadRequest("the requested category doesn't excist");
            }
            return Ok(await repository.GetAllByCategoryName(categoryName));
        }

        [HttpGet]
        [Route("PartById")]
        public async Task<IActionResult> PartById()
        {
            return Ok(await repository.GetPartsBasic());
        }


        [HttpGet]
        [Route("PartByPartId/{id}")]
        public async Task<IActionResult> PartByPartId(int id)
        {
            return Ok(await repository.GetPartById(id));
        }

        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> Basic()
        {
            return Ok(await repository.GetPartsBasic());
        }

        [HttpGet]
        [Route("Basic/{id}")]
        public async Task<IActionResult> BasicById(int id)
        {
            return Ok(await repository.GetPartsBasicById(id));
        }

        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var imageFile = repository.GetImagePathByName(filename);
            string imagePath = Path.Combine(imageDirectoryPath, $"{imageFile.FileName}");
            return PhysicalFile(imagePath, imageFile.Type);
        }

        [HttpPost]
        [Route("ImageUpload")]
        public async Task<string> PostImage( int partId = 0)
        {
            var file = Request.Form.Files[0] as IFormFile;
            try
            {
                if (file.Length > 0 && partId != 0)
                {
                    if (!System.IO.File.Exists(imageDirectoryPath + file.FileName))
                    {
                        using (FileStream filestream = System.IO.File.Create(imageDirectoryPath + file.FileName))
                        {
                            await file.CopyToAsync(filestream);
                            filestream.Flush();
                            await repository.CreateImage(file, partId);
                            return file.FileName;
                        }
                    }
                    else
                    {
                        return "imagePath is allready taken";
                    }
                }
                else
                {
                    return "failed to stream the file or id isn't valid";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
