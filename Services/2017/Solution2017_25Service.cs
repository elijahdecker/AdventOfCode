namespace AdventOfCode.Services
{
    public class Solution2017_25Service : ISolutionDayService
    {
        public Solution2017_25Service() { }

        public string FirstHalf(bool example)
        {
            List<string> lines = Utility.GetInputLines(2017,25, example);

            int answer = 0;

            foreach (string line in lines) {

            }

            return answer.ToString();
        }

        public string SecondHalf(bool example)
        {
            return "There is no problem for Day 25 part 2, solve all other problems to get the last star.";
        }
    }
}