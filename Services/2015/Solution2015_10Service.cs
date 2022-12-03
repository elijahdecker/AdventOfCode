namespace AdventOfCode.Services
{
    public class Solution2015_10Service : ISolutionDayService
    {
        public Solution2015_10Service() { }

        public string FirstHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_10.txt"));

            List<int> currentList = data.Split("\n")[0].Select(s => (int)char.GetNumericValue(s)).ToList();
            List<int> newList = new();
            int numberOfLoops = 40;

            for (int i = 0; i < numberOfLoops; i++)
            {
                int currentNumber = currentList[0];
                int currentLength = 0;

                for (int j = 0; j < currentList.Count; j++)
                {
                    int number = currentList[j];

                    if (currentNumber != number)
                    {
                        newList.Add(currentLength);
                        newList.Add(currentNumber);
                        currentNumber = number;
                        currentLength = 1;
                    }
                    else
                    {
                        currentLength++;
                    }

                    if (j == currentList.Count - 1)
                    {
                        newList.Add(currentLength);
                        newList.Add(number);
                    }
                }

                currentList = newList;
                newList = new();
            }

            return $"The length of the result after {numberOfLoops} iterations is {currentList.Count}.";
        }

        public string SecondHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_10.txt"));

            List<int> currentList = data.Split("\n")[0].Select(s => (int)char.GetNumericValue(s)).ToList();
            List<int> newList = new();
            int numberOfLoops = 50;

            for (int i = 0; i < numberOfLoops; i++)
            {
                int currentNumber = currentList[0];
                int currentLength = 0;

                for (int j = 0; j < currentList.Count; j++)
                {
                    int number = currentList[j];

                    if (currentNumber != number)
                    {
                        newList.Add(currentLength);
                        newList.Add(currentNumber);
                        currentNumber = number;
                        currentLength = 1;
                    }
                    else
                    {
                        currentLength++;
                    }

                    if (j == currentList.Count - 1)
                    {
                        newList.Add(currentLength);
                        newList.Add(number);
                    }
                }

                currentList = newList;
                newList = new();
            }

            return $"The length of the result after {numberOfLoops} iterations is {currentList.Count}.";
        }
    }
}
