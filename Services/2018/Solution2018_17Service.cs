namespace AdventOfCode.Services
{
    public class Solution2018_17Service : ISolutionDayService
    {
        public Solution2018_17Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2018_17.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2018, 17, false, answer);
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2018_17.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return await Utility.SubmitAnswer(2018, 17, true, answer);
        }
    }
}