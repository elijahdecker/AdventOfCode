namespace AdventOfCode.Services
{
    public class Solution2021_07Service : ISolutionDayService
    {
        public Solution2021_07Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2021_07.txt")).ToList();

            return $"";
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2021_07.txt")).ToList();

            return $"";
        }
    }
}
