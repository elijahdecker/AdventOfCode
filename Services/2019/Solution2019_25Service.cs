namespace AdventOfCode.Services
{
    public class Solution2019_25Service : ISolutionDayService
    {
        public Solution2019_25Service() { }

        public string FirstHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2019", "25.txt")).ToList();

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }

        public string SecondHalf()
        {
            return "There is no problem for Day 25 part 2, solve all other problems to get the last star.";
        }
    }
}