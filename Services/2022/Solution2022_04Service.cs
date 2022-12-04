using System.Text.RegularExpressions;

namespace AdventOfCode.Services
{
    public class Solution2022_04Service : ISolutionDayService{
        public Solution2022_04Service() { }

        public string FirstHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_04.txt")).ToList();

            Regex rx = new Regex(@"(\d+)-(\d+),(\d+)-(\d+)");

            int matches = 0;

            foreach (string line in lines) {
                GroupCollection match = rx.Matches(line).First().Groups;

                int num1 = int.Parse(match[1].Value);
                int num2 = int.Parse(match[2].Value);
                int num3 = int.Parse(match[3].Value);
                int num4 = int.Parse(match[4].Value);

                List<int> set1 = Enumerable.Range(num1, num2 - num1 + 1).ToList();
                List<int> set2 = Enumerable.Range(num3, num4 - num3 + 1).ToList();

                List<int> intersect = set1.Intersect(set2).ToList();

                if (intersect.SequenceEqual(set1) || intersect.SequenceEqual(set2)) {
                    matches++;
                }
            }

            string answer = matches.ToString();

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Outputs", "2022_04_1.txt"), answer);

            return answer;
        }

        public string SecondHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_04.txt")).ToList();

            Regex rx = new Regex(@"(\d+)-(\d+),(\d+)-(\d+)");

            int matches = 0;

            foreach (string line in lines) {
                GroupCollection match = rx.Matches(line).First().Groups;

                int num1 = int.Parse(match[1].Value);
                int num2 = int.Parse(match[2].Value);
                int num3 = int.Parse(match[3].Value);
                int num4 = int.Parse(match[4].Value);

                List<int> set1 = Enumerable.Range(num1, num2 - num1 + 1).ToList();
                List<int> set2 = Enumerable.Range(num3, num4 - num3 + 1).ToList();

                List<int> intersect = set1.Intersect(set2).ToList();

                if (intersect.Any()) {
                    matches++;
                }
            }

            string answer = matches.ToString();

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Outputs", "2022_04_2.txt"), answer);

            return answer;
        }
    }
}