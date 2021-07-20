using Microsoft.AspNetCore.Mvc;
using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAll();

            var usersData = ConvertToUserData(users);

            return Ok(usersData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var createdUser = await _userService.Create(user);

            return Ok(createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.Update(user);

            return Ok(updatedUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);

            return Ok();
        }

        [HttpGet("byUsername/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var users = await _userService.GetByUsername(username);

            var usersData = ConvertToUserData(users);

            return Ok(users);
        }

        private List<UserData> ConvertToUserData(IEnumerable<User> users)
        {
            var usersData = new List<UserData>();

            foreach (var user in users)
            {
                usersData.Add(new UserData
                {
                    Id = user.Id,
                    Username = user.Username
                });
            }

            return usersData;
        }
    }
}
