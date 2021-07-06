using System;
using Microsoft.AspNetCore.Mvc;
using AdventOfCode.Services;

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
        public IActionResult GetSolution(int year, int day, bool secondHalf){
            try{
                return Ok(solutionService.GetSolution(year, day, secondHalf));
            }
            catch(SolutionNotFoundException e){
                return NotFound(e.Message);
            }
        }
    }
}