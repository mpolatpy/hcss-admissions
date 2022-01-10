using System;
using Application.Lotteries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LotteriesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetLotteries()
        {
            return HandleResult(await Mediator.Send(new List.Query{}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return HandleResult(await Mediator.Send(new Detail.Query{ LotteryId = id }));
        }
    }
}