namespace AdventOfCode.Services
{
    public class Solution2017_01Service : ISolutionDayService
    {
        public Solution2017_01Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2017_01.txt")).ToList();

            char prevChar = char.MaxValue;

            int score = 0;

            foreach (char digit in lines.First())
            {
                if (digit == prevChar)
                {
                    score++;
                }

                prevChar = digit;
            }

            string answer = score.ToString();

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Outputs", "2017_01_1.txt"), answer);

            return answer;
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2017_01.txt")).ToList();

            foreach (string line in lines)
            {

            }

            string answer = "";

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Outputs", "2017_01_2.txt"), answer);

            return answer;
        }
    }
}