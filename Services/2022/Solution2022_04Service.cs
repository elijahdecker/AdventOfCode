namespace AdventOfCode.Services
{
    public class Solution2022_04Service : ISolutionDayService
    {
        public Solution2022_04Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_04.txt")).ToList();

            int matches = lines.Select(line => line.QuickRegex(@"(\d+)-(\d+),(\d+)-(\d+)").ToInts()).Sum(digits =>
            {
                int value = 0;

                List<int> set1 = Enumerable.Range(digits[0], digits[1] - digits[0] + 1).ToList();
                List<int> set2 = Enumerable.Range(digits[2], digits[3] - digits[2] + 1).ToList();

                List<int> intersect = set1.Intersect(set2).ToList();

                if (intersect.SequenceEqual(set1) || intersect.SequenceEqual(set2))
                {
                    value = 1;
                }

                return value;
            });

            return matches.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_04.txt")).ToList();

            int matches = lines.Select(line => line.QuickRegex(@"(\d+)-(\d+),(\d+)-(\d+)").ToInts()).Sum(digits =>
            {
                int value = 0;

                List<int> set1 = Enumerable.Range(digits[0], digits[1] - digits[0] + 1).ToList();
                List<int> set2 = Enumerable.Range(digits[2], digits[3] - digits[2] + 1).ToList();

                List<int> intersect = set1.Intersect(set2).ToList();

                if (intersect.Any())
                {
                    value = 1;
                }

                return value;
            });

            return matches.ToString();
        }
    }
}