namespace AdventOfCode.Services
{
    public interface ISolutionDayService
    {
        Task<string> FirstHalf(bool send);
        Task<string> SecondHalf(bool send);
    }
}