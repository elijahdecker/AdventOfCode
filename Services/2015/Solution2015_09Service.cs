namespace AdventOfCode.Services
{
    public class Solution2015_09Service : ISolutionDayService
    {
        public Solution2015_09Service() { }

        public async Task<string> FirstHalf(bool send)
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_09.txt"));

            List<string> lines = data.Split("\n").SkipLast(1).ToList();

            Dictionary<string, int> distances = lines.ToDictionary(d => d.Split(" = ")[0], d => Int32.Parse(d.Split(" = ")[1]));

            List<string> towns = new();
            lines.ForEach(line =>
            {
                string[] strings = line.Split(" ");
                towns.Add(strings[0]);
                towns.Add(strings[2]);
            });

            IEnumerable<string> townsDistinct = towns.Distinct();

            IEnumerable<IEnumerable<string>> permutations = GetPermutations(townsDistinct, townsDistinct.Count());

            int minDistance = int.MaxValue;
            foreach (IEnumerable<string> permutation in permutations)
            {
                int distance = 0;

                for (int i = 0; i < permutation.Count() - 1; i++)
                {
                    string key1 = $"{permutation.ElementAt(i)} to {permutation.ElementAt(i + 1)}";
                    string key2 = $"{permutation.ElementAt(i + 1)} to {permutation.ElementAt(i)}";

                    if (distances.ContainsKey(key1))
                    {
                        distance += distances[key1];
                    }
                    else
                    {
                        distance += distances[key2];
                    }
                }

                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }

            return await Task.FromResult($"The minimum distance between towns is {minDistance}.");
        }

        public async Task<string> SecondHalf(bool send)
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_09.txt"));

            List<string> lines = data.Split("\n").SkipLast(1).ToList();

            Dictionary<string, int> distances = lines.ToDictionary(d => d.Split(" = ")[0], d => Int32.Parse(d.Split(" = ")[1]));

            List<string> towns = new();
            lines.ForEach(line =>
            {
                string[] strings = line.Split(" ");
                towns.Add(strings[0]);
                towns.Add(strings[2]);
            });

            IEnumerable<string> townsDistinct = towns.Distinct();

            IEnumerable<IEnumerable<string>> permutations = GetPermutations(townsDistinct, townsDistinct.Count());

            int maxDistance = 0;
            foreach (IEnumerable<string> permutation in permutations)
            {
                int distance = 0;

                for (int i = 0; i < permutation.Count() - 1; i++)
                {
                    string key1 = $"{permutation.ElementAt(i)} to {permutation.ElementAt(i + 1)}";
                    string key2 = $"{permutation.ElementAt(i + 1)} to {permutation.ElementAt(i)}";

                    if (distances.ContainsKey(key1))
                    {
                        distance += distances[key1];
                    }
                    else
                    {
                        distance += distances[key2];
                    }
                }

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }

            return await Task.FromResult($"The maximum distance between towns is {maxDistance}.");
        }

        static IEnumerable<IEnumerable<string>> GetPermutations(IEnumerable<string> list, int length)
        {
            if (length == 1) return list.Select(t => new string[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new string[] { t2 }));
        }
    }
}
