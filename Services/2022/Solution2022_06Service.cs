namespace AdventOfCode.Services
{
    public class Solution2022_06Service : ISolutionDayService
    {
        public Solution2022_06Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022", "06.txt")).ToList();

            int answer = 0;

            List<char> lastFour = new();

            foreach (char line in lines.First())
            {
                if (lastFour.Count() == 4)
                {
                    lastFour.RemoveAt(0);
                }

                lastFour.Add(line);

                answer++;

                if (lastFour.Distinct().Count() == 4 && lastFour.Count() == 4)
                {
                    break;
                }
            }

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022", "06.txt")).ToList();


            int answer = 0;

            List<char> lastFourteen = new();

            foreach (char line in lines.First())
            {
                if (lastFourteen.Count() == 14)
                {
                    lastFourteen.RemoveAt(0);
                }

                lastFourteen.Add(line);

                answer++;

                if (lastFourteen.Distinct().Count() == 14 && lastFourteen.Count() == 14)
                {
                    break;
                }
            }
            return answer.ToString();
        }
    }
}