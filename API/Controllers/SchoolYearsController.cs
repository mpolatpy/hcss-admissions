using Application.SchoolYears;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SchoolYearsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetSchoolYears()
        {
            return HandleResult(await Mediator.Send(new List.Query{}));
        }

        [HttpGet("{schoolYear}")]
        public async Task<IActionResult> GetSchoolYearByName(string schoolYear)
        {
            return HandleResult(await Mediator.Send(new Detail.Query{SchoolYearName = schoolYear}));
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateApplication(SchoolYear schoolYear)
        {
            return HandleResult(await Mediator.Send(new Create.Command{SchoolYear = schoolYear}));
        }
    }
}