namespace AdventOfCode.Services
{
    public class Solution2020_21Service : ISolutionDayService
    {
        public Solution2020_21Service() { }

        public string FirstHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2020", "21.txt")).ToList();

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2020", "21.txt")).ToList();

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }
    }
}