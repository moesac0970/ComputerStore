using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ComputerStore.Api.Controllers
{

    public class ControllerCrudBase<T, R> : ControllerBase
       where T : EntityBase
       where R : Repository<T>
    {
        protected R repository;
        public ControllerCrudBase(R r)
        {
            repository = r;
        }

        // GET: T
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await repository.ListAll();
            Console.WriteLine(result);
            return Ok(result);
        }

        // GET: T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetById(id));
        }

        // PUT: T/5
        [HttpPut("{id}")]
        [Authorize("AdminRole")]
        public async Task<IActionResult> Put([FromRoute] int id,
            [FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != entity.Id) return BadRequest();

            T updated = await repository.Update(entity);

            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // POST: T
        [HttpPost]
        [Authorize("AdminRole")]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: T/3
        [HttpDelete("{id}")]
        [Authorize("AdminRole")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var deleted = await repository.Delete(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }

    }
}
