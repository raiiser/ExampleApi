using Example.Api.Business.DTO;
using Example.Api.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Example.Api.Web.Controllers
{
    public class GenericController<TEntity, TDto> : ControllerBase where TEntity : class where TDto : BaseDto
    {
        protected readonly IService<TEntity, TDto> Service;

        public GenericController(IService<TEntity, TDto> service)
        {
            this.Service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TDto>> Get()
        {
            return this.Service.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TDto> Get(int id)
        {
            return this.Service.GetById(id);
        }

        [HttpPost]
        public ActionResult<TDto> Post([FromBody] TDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return this.Service.Add(user);
        }

        [HttpPut("{id}")]
        public ActionResult<TDto> Put(int id, [FromBody] TDto user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            return this.Service.Update(user);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.Service.Delete(id);
            return Ok();
        }
    }
}
