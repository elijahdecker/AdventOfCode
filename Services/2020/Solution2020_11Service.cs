namespace AdventOfCode.Services
{
    public class Solution2020_11Service : ISolutionDayService
    {
        public Solution2020_11Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2020_11.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2020, 11, false, answer);
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2020_11.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2020, 11, true, answer);
        }
    }
}