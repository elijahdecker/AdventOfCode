namespace AdventOfCode.Services
{
    public class Solution2015_01Service : ISolutionDayService
    {
        public Solution2015_01Service() { }

        public string FirstHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_01.txt"));

            int floor = 0;

            foreach (char character in data)
            {
                if (character == '(')
                {
                    floor++;
                }
                else if (character == ')')
                {
                    floor--;
                }
            }

            return $"Santa's final floor: {floor}.";
        }

        public string SecondHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_01.txt"));

            int floor = 0;
            int position = 1;

            foreach (char character in data)
            {
                if (character == '(')
                {
                    floor++;
                }
                else if (character == ')')
                {
                    floor--;
                }

                if (floor == -1)
                {
                    break;
                }

                position++;
            }

            return $"Position that Santa enters the basement: {position}.";
        }
    }
}