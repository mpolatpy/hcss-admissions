using Application.Students;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StudentController : BaseApiController
    {
        [HttpGet("list")]
        public async Task<IActionResult> GetStudents(){
            return HandleResult(await Mediator.Send(new List.Query{}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id){
            return HandleResult(await Mediator.Send(new Details.Query{StudentId = id}));
        }
    }
}