namespace AdventOfCode.Services
{
    public interface ISolutionService
    {
        Task<string> GetSolution(int year, int day, bool secondHalf, bool send);
    }
}