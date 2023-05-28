using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IWebHostEnvironment webHostEnvironment;
        private IRepository repository;
        public ReservationController(IRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest("Value must be passed into request");
            return Ok(repository[id]);
        }
        //[HttpPost]
        //public IActionResult Post([FromBody] Reservation reservation)
        //{

        //}
        [HttpPut]
        public Reservation Put([FromForm] Reservation reservation) { return repository.UpdateReservation(reservation); }
        [HttpDelete("{id}")]
        public void Delete (int id) { repository.DeleteReservation(id); }
    }
}
