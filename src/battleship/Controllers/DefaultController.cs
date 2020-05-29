using battleship.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using battleship.Models;


namespace battleship.Controllers
{
    [Route("v1/[controller]")]
    public class DefaultController : ControllerBase
    {
        private const string ErrorMessage = "failed to process request";
        private const string SuccessMessage = "successfully processed request";
        private const string HitMessage = "hit";
        private const string MissMessage = "miss";

        private readonly IBattleFieldService _battlefieldService;

        public DefaultController(IBattleFieldService battlefieldService)
        {
            _battlefieldService = battlefieldService;
        }

        [HttpPut]
        public IActionResult Initialize([FromBody]Ship ship)
        {
            var success = false;

            if (ship != null)
            {
                success = _battlefieldService.AddShip(ship);
            }

            return success ? CreateResponse(SuccessMessage, success) : CreateResponse(ErrorMessage, success);
        }

        [HttpPost]
        public IActionResult Shoot([FromBody]Shot shot)
        {
            string hitMissMessage = string.Empty;
            var success = false;

            if (shot != null)
            {
                hitMissMessage = _battlefieldService.Attack(shot) ? HitMessage : MissMessage;
                success = true;
            };

            return success ? CreateResponse(hitMissMessage, success) : CreateResponse(ErrorMessage, success);
        }

        private IActionResult CreateResponse(object result, bool success)
        {
            if (!success) return BadRequest(result);
            var response = JsonConvert.SerializeObject(result);
            return Ok(response);
        }
    }
}