namespace AdventOfCode.Services
{
    public interface ISolutionDayService
    {
        Task<string> FirstHalf();
        Task<string> SecondHalf();
    }
}