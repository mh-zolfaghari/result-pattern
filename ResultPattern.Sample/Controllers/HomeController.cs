using Microsoft.AspNetCore.Mvc;
using ResultPattern.Sample.Controllers.Base;
using ResultPattern.Sample.SampleServices;
using ResultPattern.Tools;

namespace ResultPattern.Sample.Controllers
{
    public class HomeController(SampleService sampleService) : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        public IActionResult GetSuccess()
        {
            var result = Result.Success();
            return OkResult(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<Person>), StatusCodes.Status200OK)]
        public IActionResult GetPerson([FromQuery] string name)
        {
            return OkResult(sampleService.GetPersonByName(name));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<IEnumerable<Person>>), StatusCodes.Status200OK)]
        public IActionResult GetPersons()
        {
            return OkResult(sampleService.GetAllPersons());
        }
    }
}
