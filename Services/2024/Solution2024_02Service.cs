namespace AdventOfCode.Services
{
    // (ctrl/command + click) the link to open the input file
    // file://./../../Inputs/2024/02.txt
    public class Solution2024_02Service : ISolutionDayService
    {
        public string FirstHalf(bool example)
        {
            List<string> lines = Utility.GetInputLines(2024, 2, example);

            int answer = 0;

            foreach (string line in lines)
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var ascending = numbers[0] - numbers[1] < 0;
                var safe = true;

                for (int i = 1; i < numbers.Count(); i++) {
                    var difference = numbers[i] - numbers[i - 1];
                    if (Math.Abs(difference) > 0 && Math.Abs(difference) <= 3) {
                        if (!(difference > 0 && ascending || difference < 0 && !ascending)) {
                            safe = false;
                            break;
                        }
                    } else {
                        safe = false;
                        break;
                    }
                }

                if (safe) answer++;
            }

            return answer.ToString();
        }

        public string SecondHalf(bool example)
        {
            List<string> lines = Utility.GetInputLines(2024, 2, example);

            int answer = 0;

            foreach (string line in lines)
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var safe = true;

                for (int x = 0; x < numbers.Count(); x++) {
                    var tempList = new List<int>(numbers);
                    tempList.RemoveAt(x);
                    var ascending = tempList[0] - tempList[1] < 0;
                    
                    safe = true;
                    for (int i = 1; i < tempList.Count(); i++) {
                        var difference = tempList[i] - tempList[i - 1];
                        if (Math.Abs(difference) > 0 && Math.Abs(difference) <= 3) {
                            if (!(difference > 0 && ascending || difference < 0 && !ascending)) {
                                safe = false;
                                break;
                            }
                        } else {
                            safe = false;
                            break;
                        }
                    }
                    if (safe) break;
                }
                if (safe) answer++;
            }

            return answer.ToString();
        }
    }
}