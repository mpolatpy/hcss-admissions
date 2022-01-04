using Application.Applications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApplicationsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            return HandleResult(await Mediator.Send(new List.Query{}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Detail.Query{ApplicationId = id}));
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateApplication(Domain.Application application)
        {
            return HandleResult(await Mediator.Send(new Create.Command{Application = application}));
        }
    }
}