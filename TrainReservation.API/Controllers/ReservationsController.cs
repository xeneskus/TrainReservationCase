using Microsoft.AspNetCore.Mvc;
using TrainReservation.Models;
using TrainReservation.Services.Interfaces;

namespace TrainReservation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("reserve")]
        public ActionResult<ReservationOutput> Reserve([FromBody] ReservationInput reservationInput)
        {
            var result = _reservationService.Reserve(reservationInput);
            if (result.Reservationable)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

