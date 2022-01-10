using Application.Schools;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SchoolsController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            return HandleResult(await Mediator.Send(new List.Query{}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            return HandleResult(await Mediator.Send(new Detail.Query{SchoolId = id}));
        }

        [HttpPost("new")]
        public async Task<IActionResult> AddNewSchool(School school)
        {
            return HandleResult(await Mediator.Send(new Create.Command{School = school}));
        }
    }
}