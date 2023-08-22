namespace AdventOfCode.Services
{
    public class Solution2022_10Service : ISolutionDayService
    {
        public Solution2022_10Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022", "10.txt")).ToList();

            int answer = 0;
            int x = 1;
            int cycle = 0;

            List<int> signals = new() { 20, 60, 100, 140, 180, 220 };

            foreach (string line in lines)
            {
                if (line == "noop")
                {
                    cycle++; // Takes 1 cycle

                    if (signals.Contains(cycle))
                    {
                        answer += x * cycle;
                    }
                }
                else if (line.StartsWith("addx"))
                {
                    int value = int.Parse(line.QuickRegex(@"addx (-?\d+)").First());

                    cycle++;

                    if (signals.Contains(cycle))
                    {
                        answer += x * cycle;
                    }

                    cycle++;

                    if (signals.Contains(cycle))
                    {
                        answer += x * cycle;
                    }

                    x += value;
                }
            }

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022", "10.txt")).ToList();

            int x = 1;
            int position = 0;

            string output = string.Empty;
            foreach (string line in lines)
            {
                if (line == "noop")
                {
                    output += (position % 40 == x || position % 40 == x + 1 || position % 40 == x - 1) ? "#" : ".";

                    position++;
                }
                else if (line.StartsWith("addx"))
                {
                    int value = int.Parse(line.QuickRegex(@"addx (-?\d+)").First());

                    output += (position % 40 == x || position % 40 == x + 1 || position % 40 == x - 1) ? "#" : ".";
                    position++;

                    output += (position % 40 == x || position % 40 == x + 1 || position % 40 == x - 1) ? "#" : ".";
                    position++;

                    x += value;
                }
            }

            return Utility.ParseASCIILetters(output, 6);
        }
    }
}