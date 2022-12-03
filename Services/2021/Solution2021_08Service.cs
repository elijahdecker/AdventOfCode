namespace AdventOfCode.Services
{
    public class Solution2021_08Service : ISolutionDayService
    {
        public Solution2021_08Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2021_08.txt")).ToList();

            return $"";
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2021_08.txt")).ToList();

            return $"";
        }
    }
}
