using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayaksEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> Get([FromRoute]int id) 
        {
            try
            {
                return _userService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<User>> GetAllFullData(IUserService _userService)
        {
            return _userService.GetAllFullData();
        }

        [Authorize (Policy = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] UserCreateRequest userCreateRequest)
        {
            var newObj = _userService.Create(userCreateRequest);
            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, newObj);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            try
            {
                _userService.Update(id, userUpdateRequest);
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
                _userService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
