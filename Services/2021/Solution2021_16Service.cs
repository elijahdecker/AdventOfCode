namespace AdventOfCode.Services
{
    public class Solution2021_16Service : ISolutionDayService
    {
        public Solution2021_16Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2021_16.txt")).ToList();

            return $"";
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2021_16.txt")).ToList();

            return $"";
        }
    }
}
