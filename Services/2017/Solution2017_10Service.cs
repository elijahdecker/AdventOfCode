namespace AdventOfCode.Services
{
    public class Solution2017_10Service : ISolutionDayService
    {
        public Solution2017_10Service() { }

        public string FirstHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2017", "10.txt")).ToList();

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2017", "10.txt")).ToList();

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }
    }
}