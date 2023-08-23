namespace AdventOfCode.Services
{
    public class Solution2015_07Service : ISolutionDayService
    {
        public Solution2015_07Service() { }

        public string FirstHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2015", "07.txt")).ToList();

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2015", "07.txt")).ToList();

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }
    }
}