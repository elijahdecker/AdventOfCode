namespace AdventOfCode.Services
{
    public class Solution2018_25Service : ISolutionDayService
    {
        public Solution2018_25Service() { }

        public string FirstHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2018", "25.txt")).ToList();

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