namespace AdventOfCode.Services
{
    public interface ISolutionService
    {
        string GetSolution(int year, int day, bool secondHalf);
        Task<bool> SendSolution(int year, int day, bool secondHalf);
    }
}