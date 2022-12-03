namespace AdventOfCode.Services
{
    public class Solution2021_09Service : ISolutionDayService
    {
        public Solution2021_09Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2021_09.txt")).ToList();

            return $"";
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2021_09.txt")).ToList();

            return $"";
        }
    }
}
