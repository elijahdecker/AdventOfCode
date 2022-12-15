namespace AdventOfCode.Services
{
    public class Solution2015_01Service : ISolutionDayService
    {
        public Solution2015_01Service() { }

        public async Task<string> FirstHalf(bool send)
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

            return await Task.FromResult($"Santa's final floor: {floor}.");
        }

        public async Task<string> SecondHalf(bool send)
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

            return await Task.FromResult($"Position that Santa enters the basement: {position}.");
        }
    }
}