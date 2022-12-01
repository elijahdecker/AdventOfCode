namespace AdventOfCode.Services
{
    public class Solution2021_01Service: ISolutionDayService{
        public Solution2021_01Service(){}

        public string FirstHalf(){
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2021_01.txt")).ToList();

            List<int> calories = new();

            int calorie = 0;

            foreach (string line in lines) {
                if (string.IsNullOrWhiteSpace(line)) {
                    calories.Add(calorie);
                    calorie = 0;
                }
                else {
                    calorie += int.Parse(line);
                }
            }

            return $"{calories.Max()}";
        }

        public string SecondHalf(){
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2021_01.txt")).ToList();

            return $"";
        }
    }
}
                        