using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using KayaksEcommerce.Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayaksEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KayakController : ControllerBase
    {
        private readonly IKayakService _kayakService;
        public KayakController(IKayakService kayakService)
        {
            _kayakService = kayakService;
        }

        [HttpGet]
        public ActionResult<List<KayakDto>> GetAll()
        {
            return _kayakService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<KayakDto> Get([FromRoute] int id)
        {
            try
            {
                return _kayakService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<Kayak>> GetAllFullData(IKayakService _kayakService)
        {
            return _kayakService.GetAllFullData();
        }

        [HttpPost]
        public IActionResult Create([FromBody] KayakCreateRequest kayakCreateRequest)
        {
            var newObj = _kayakService.Create(kayakCreateRequest);
            return CreatedAtAction(nameof(Get), new { id = newObj.id }, newObj);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] KayakUpdateRequest kayakUpdateRequest)
        {
            try
            {
                _kayakService.Update(id, kayakUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _kayakService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
