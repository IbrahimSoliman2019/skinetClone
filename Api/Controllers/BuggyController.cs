using Api.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _store;
        public BuggyController(StoreContext store)
        {
            _store = store;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var thing = _store.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));

            }
            return Ok();

        }
          [HttpGet("servererror")]
        public ActionResult Getservererror()
        {
            var thing = _store.Products.Find(42);
            var thing2 = thing.Name;
            return Ok();

        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));

        }
         [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();

        }
    }
}