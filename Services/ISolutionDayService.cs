namespace AdventOfCode.Services
{
    public interface ISolutionDayService
    {
        /// <summary>
        /// Execute this day's first half
        /// </summary>
        /// <param name="send"></param>
        /// <returns></returns>
        string FirstHalf();

        /// <summary>
        /// Execute this day's second half
        /// </summary>
        /// <param name="send"></param>
        /// <returns></returns>
        string SecondHalf();
    }
}