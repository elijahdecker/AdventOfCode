namespace AdventOfCode.Services
{
    public class Solution2015_25Service : ISolutionDayService
    {
        public Solution2015_25Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2015", "25.txt")).ToList();

            List<int> values = lines.First().QuickRegex(@"To continue, please consult the code grid in the manual.  Enter the code at row (\d+), column (\d+).").ToInts();

            int row = values.First();
            int column = values.Last();

            int item = Enumerable.Range(1, column).Sum();
            int step = column;

            for (int i = 1; i < row; i++) {
                item += step;
                step++;
            }

            long answer = 20151125;

            for (int i = 0; i < item - 1; i++) {
                answer = answer * (long)252533 % (long)33554393;
            }

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2015", "25.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return answer.ToString();
        }
    }
}