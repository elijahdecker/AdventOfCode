namespace AdventOfCode.Services
{
    public class Solution2022_01Service : ISolutionDayService
    {
        public Solution2022_01Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_01.txt")).ToList();

            int answer = lines.ChunkByExclusive(string.IsNullOrWhiteSpace).Select(elf => elf.ToInts().Sum()).Max();

            return $"There are {answer} calories caried by the elf with the most calories";
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_01.txt")).ToList();

            List<int> calories = lines.ChunkByExclusive(string.IsNullOrWhiteSpace).Select(elf => elf.ToInts().Sum()).ToList();

            int total3 = calories.OrderDescending().Take(3).Sum();

            return $"There are {total3} calories carried by the 3 elves with the most calories";
        }
    }
}