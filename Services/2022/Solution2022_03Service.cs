namespace AdventOfCode.Services
{
    public class Solution2022_03Service : ISolutionDayService{
        public Solution2022_03Service() { }

        public string FirstHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_03.txt")).ToList();

            int sum = 0;

            foreach (string line in lines) {
                List<char> firstHalf = line.Take(line.Count() / 2).ToList();
                List<char> secondHalf = line.TakeLast(line.Count() / 2).ToList();

                char itemType = firstHalf.First(c => secondHalf.Contains(c));

                int value = 0;

                if (char.IsLower(itemType)) {
                    value = (int)itemType - (int)'a' + 1;
                }
                else {
                    value = (int)itemType - (int)'A' + 27;
                }

                sum += value;
            }

            return $"{sum}";
        }

        public string SecondHalf()
        {
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2022_03.txt")).ToList();
            
            int sum = 0;

            for (int i = 0; i < lines.Count; i += 3) {
                List<char> letters = (lines[i] + lines[i + 1] + lines[i + 2]).ToCharArray().ToList();

                char itemType = letters.First(l => lines[i].Contains(l) && lines[i + 1].Contains(l) && lines[i + 2].Contains(l));

                int value = 0;

                if (char.IsLower(itemType)) {
                    value = (int)itemType - (int)'a' + 1;
                }
                else {
                    value = (int)itemType - (int)'A' + 27;
                }
                
                sum += value;
            }

            return $"{sum}";
        }
    }
}