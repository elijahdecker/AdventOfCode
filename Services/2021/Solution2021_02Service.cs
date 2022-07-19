namespace AdventOfCode.Services
{
    public class Solution2021_02Service: ISolutionDayService{
        public Solution2021_02Service(){}

        public string FirstHalf(){
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2021_02.txt")).ToList();

            return $"";
        }

        public string SecondHalf(){
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2021_02.txt")).ToList();

            return $"";
        }
    }
}
                        