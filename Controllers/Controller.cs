using AdventOfCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AdventOfCode.Controllers
{
    [ApiController]
    [Route("api")]
    public class Controller : ControllerBase
    {
        private readonly ISolutionService solutionService;

        public Controller(ISolutionService solutionService)
        {
            this.solutionService = solutionService;
        }

        [HttpGet]
        public ActionResult<string> GetSolution([FromQuery, BindRequired] int year = 2015, [FromQuery, BindRequired] int day = 1, bool secondHalf = false)
        {
            try
            {
                return solutionService.GetSolution(year, day, secondHalf);
            }
            catch (SolutionNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RunPuzzleHelper()
        {
            await PuzzleHelper.Run();

            return Ok();
        }
    }
}