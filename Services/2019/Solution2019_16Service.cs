namespace AdventOfCode.Services
{
    public class Solution2019_16Service : ISolutionDayService
    {
        public Solution2019_16Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2019_16.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2019, 16, false, answer);
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2019_16.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2019, 16, true, answer);
        }
    }
}