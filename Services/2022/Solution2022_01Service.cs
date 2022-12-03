namespace AdventOfCode.Services
{
    public class Solution2022_01Service : ISolutionDayService
    {
        public Solution2022_01Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_01.txt")).ToList();

            List<int> calories = new();

            int calorie = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    calories.Add(calorie);
                    calorie = 0;
                }
                else
                {
                    calorie += int.Parse(line);
                }
            }

            return $"There are {calories.Max()} calories caried by the elf with the most calories";
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_01.txt")).ToList();

            List<int> calories = new();

            int calorie = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    calories.Add(calorie);
                    calorie = 0;
                }
                else
                {
                    calorie += int.Parse(line);
                }
            }

            int total3 = calories.OrderDescending().Take(3).Sum();

            return $"There are {total3} calories carried by the 3 elves with the most calories";
        }
    }
}