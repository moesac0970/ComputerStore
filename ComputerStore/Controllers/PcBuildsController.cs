using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models.PcBuilds;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PcBuildsController : ControllerBase
    {
        private readonly PcBuildRepository pcBuildRepository;

        public PcBuildsController(PcBuildRepository pcBuildRepository)
        {
            this.pcBuildRepository = pcBuildRepository ?? throw new ArgumentNullException(nameof(pcBuildRepository));
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<PcBuild> ReadBuild(string id)
        {
            return pcBuildRepository.ReadBuildById(id);
        }

        [HttpGet]
        public ActionResult<List<PcBuild>> ReadBuilds()
        {
            return pcBuildRepository.ReadBuilds();
        }

        [HttpPost]
        public ActionResult<string> CreateFlow([FromBody] PcBuild pcBuild)
        {
            pcBuildRepository.CreatePcBuild(pcBuild);

            return pcBuild.Id;
        }


    }
}
