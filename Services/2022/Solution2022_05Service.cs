namespace AdventOfCode.Services
{
    public class Solution2022_05Service : ISolutionDayService
    {
        public Solution2022_05Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_05.txt")).ToList();

            List<Stack<string>> crates = lines
                .TakeWhile(l => !string.IsNullOrWhiteSpace(l)) // Only get the part of the file with the initial crate configuration
                .SkipLast(1) // Skip the last line with the numbers
                .QuickRegex(@".(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).") // Parse the labels of the crates
                .Pivot() // Pivot the 2D list of parsed crates
                .Select(l => new Stack<string>(l.Where(x => !string.IsNullOrWhiteSpace(x)))) // Filter out empty spaces and add the list to the stack
                .ToList();

            // Start parsing after the empty line
            List<string> instructions = lines.SkipWhile(l => !string.IsNullOrWhiteSpace(l)).Skip(1).ToList();

            foreach (string line in instructions)
            {
                List<int> nums = line.QuickRegex(@"move (\d+) from (\d+) to (\d+)").ToInts();

                for (int i = 0; i < nums[0]; i++)
                {
                    string box = crates[nums[1] - 1].Pop();
                    crates[nums[2] - 1].Push(box);
                }
            }

            string answer = new(crates.Select(c => c.Pop()[0]).ToArray());

            return await Utility.SubmitAnswer(2022, 5, false, answer);
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_05.txt")).ToList();

            List<Stack<string>> crates = lines
                .TakeWhile(l => !string.IsNullOrWhiteSpace(l)) // Only get the part of the file with the initial crate configuration
                .SkipLast(1) // Skip the last line with the numbers
                .QuickRegex(@".(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).\s.(.).") // Parse the labels of the crates
                .Pivot() // Pivot the 2D list of parsed crates
                .Select(l => new Stack<string>(l.Where(x => !string.IsNullOrWhiteSpace(x)))) // Filter out empty spaces and add the list to the stack
                .ToList();

            // Start parsing after the empty line
            List<string> instructions = lines.SkipWhile(l => !string.IsNullOrWhiteSpace(l)).Skip(1).ToList();

            foreach (string line in instructions)
            {
                List<int> nums = line.QuickRegex(@"move (\d+) from (\d+) to (\d+)").ToInts();

                List<string> moved = new();

                for (int i = 0; i < nums[0]; i++)
                {
                    string box = crates[nums[1] - 1].Pop();
                    moved.Add(box);
                }

                moved.Reverse();

                foreach (string box in moved)
                {
                    crates[nums[2] - 1].Push(box);
                }
            }

            string answer = new(crates.Select(c => c.Pop()[0]).ToArray());

            return await Utility.SubmitAnswer(2022, 5, true, answer);
        }
    }
}