namespace AdventOfCode.Services
{
    public class Solution2019_25Service : ISolutionDayService
    {
        public Solution2019_25Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2019_25.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2019, 25, false, answer);
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2019_25.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2019, 25, true, answer);
        }
    }
}