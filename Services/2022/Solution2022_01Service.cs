namespace AdventOfCode.Services
{
    public class Solution2022_01Service : ISolutionDayService
    {
        public Solution2022_01Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_01.txt")).ToList();

            int answer = lines.ChunkByExclusive(string.IsNullOrWhiteSpace).Select(elf => elf.ToInts().Sum()).Max();

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_01.txt")).ToList();

            List<int> calories = lines.ChunkByExclusive(string.IsNullOrWhiteSpace).Select(elf => elf.ToInts().Sum()).ToList();

            int total3 = calories.OrderDescending().Take(3).Sum();

            return total3.ToString();
        }
    }
}