using Application.Interfaces;
using Application.Models;
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

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return _service.GetAll();
        }
    }
}
