using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayaksEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService userService)
        {
            _service = userService;
        }

        [HttpGet("{name}")]
        public IActionResult Get([FromRoute]string name)
        {
            return Ok(_service.Get(name));
        }
    }
}
