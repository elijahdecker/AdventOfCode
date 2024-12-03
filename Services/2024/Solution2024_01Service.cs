namespace AdventOfCode.Services
{
    // (ctrl/command + click) the link to open the input file
    // file://./../../Inputs/2024/01.txt
    public class Solution2024_01Service : ISolutionDayService
    {
        public string FirstHalf(bool example)
        {
            List<string> lines = Utility.GetInputLines(2024, 1, example);

            int answer = 0;
            var leftColumn = new List<int>();
            var rightColumn = new List<int>();
            foreach (string line in lines)
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                leftColumn.Add(Int32.Parse(numbers[0]));
                rightColumn.Add(Int32.Parse(numbers[1]));
            }

            leftColumn.Sort();
            rightColumn.Sort();

            for (int i = 0; i < lines.Count(); i++) {
                answer += Math.Abs(leftColumn[i] - rightColumn[i]);
            }

            return answer.ToString();
        }

        public string SecondHalf(bool example)
        {
            List<string> lines = Utility.GetInputLines(2024, 1, example);

            int answer = 0;
            var leftColumn = new List<int>();
            var rightColumn = new List<int>();
            foreach (string line in lines)
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                leftColumn.Add(Int32.Parse(numbers[0]));
                rightColumn.Add(Int32.Parse(numbers[1]));
            }

            leftColumn.Sort();
            rightColumn.Sort();

            for (int i = 0; i < lines.Count(); i++) {
                answer += leftColumn[i] * rightColumn.Where(x => x == leftColumn[i]).Count();
            }
            
            return answer.ToString();
        }
    }
}