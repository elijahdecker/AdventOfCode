namespace AdventOfCode.Services
{
    public class Solution2022_25Service : ISolutionDayService
    {
        public Solution2022_25Service() { }

        public string FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_25.txt")).ToList();

            long answerDecimal = 0;

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++) {
                    long value = 0;

                    switch (line[i]) {
                        case '2':
                            value = 2;
                            break;
                        case '1':
                            value = 1;
                            break;
                        case '0':
                            value = 0;
                            break;
                        case '-':
                            value = -1;
                            break;
                        case '=':
                            value = -2;
                            break;
                        default:
                            // Shouldn't happen
                            break;
                    }
                    
                    answerDecimal += value * (long)Math.Pow(5, line.Length - 1 - i);
                }
            }

            string answer = string.Empty;

            // Convert number to SNAFU
            long answerSoFar = 0;
            for (int i = 0; i < Math.Ceiling(Math.Log(answerDecimal, 5)); i++) {
                long value = ((answerDecimal - answerSoFar) / (long)Math.Pow(5, i)) % 5;

                switch (value) {
                    case 0:
                        answer += '0';
                        break;
                    case 1:
                        answer += '1';
                        break;
                    case 2:
                        answer += '2';
                        break;
                    case 3:
                        answer += '=';
                        value = -2;
                        break;
                    case 4:
                        answer += '-';
                        value = -1;
                        break;
                    default:
                        // Shouldn't happen
                        break;
                }

                answerSoFar += value * (long)Math.Pow(5,i);
            }

            answer = new string(answer.Reverse().ToArray());

            return answer.ToString();
        }

        public string SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_25.txt")).ToList();

            int answer = 0;

            foreach (string line in lines)
            {

            }

            return answer.ToString();
        }
    }
}