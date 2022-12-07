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
        private readonly IPuzzleHelperService puzzleHelperService;

        public Controller(ISolutionService solutionService, IPuzzleHelperService puzzleHelperService)
        {
            this.solutionService = solutionService;
            this.puzzleHelperService = puzzleHelperService;
        }

        [HttpGet("run-solution")]
        public async Task<ActionResult<string>> GetSolution([FromQuery, BindRequired] int year = 2015, [FromQuery, BindRequired] int day = 1, bool secondHalf = false)
        {
            try
            {
                return await solutionService.GetSolution(year, day, secondHalf);
            }
            catch (SolutionNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("puzzle-helper")]
        public async Task<string> RunPuzzleHelper()
        {
            return await puzzleHelperService.Run();
        }

        [HttpPost("puzzle-helper-daily")]
        public async Task<string> RunPuzzleHelper(int year, int day)
        {
            return await puzzleHelperService.RunDaily(year, day);
        }
    }
}