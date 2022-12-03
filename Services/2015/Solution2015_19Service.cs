namespace AdventOfCode.Services
{
    public class Solution2015_19Service : ISolutionDayService
    {
        public Solution2015_19Service() { }

        public string FirstHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_19.txt"));

            string[] parsedData = data.Split("\n\n");
            string molecule = parsedData[1].Split("\n")[0];
            string[] replacements = parsedData[0].Split("\n");
            HashSet<string> distinctMolecules = new();

            foreach (string replacement in replacements)
            {
                string source = replacement.Split(" => ")[0];
                string destination = replacement.Split(" => ")[1];

                string[] splits = molecule.Split(source);

                for (int i = 0; i < splits.Length - 1; i++)
                {
                    string newMolecule = "";

                    for (int j = 0; j < i; j++)
                    {
                        newMolecule += $"{splits[j]}{source}";
                    }

                    newMolecule += $"{splits[i]}{destination}";

                    for (int j = i + 1; j < splits.Length; j++)
                    {
                        newMolecule += splits[j];

                        if (j != splits.Length - 1)
                        {
                            newMolecule += source;
                        }
                    }

                    distinctMolecules.Add(newMolecule);
                }
            }

            return $"{distinctMolecules.Count} can be created from 1 replacement.";
        }

        public string SecondHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_19.txt"));

            string[] parsedData = data.Split("\n\n");
            string molecule = parsedData[1].Split("\n")[0];
            Random rnd = new Random(); // There is probably a better way to do this, but this is my compromise between brute force and an actual solution
            string[] replacements = parsedData[0].Split("\n").OrderBy(p => rnd.Next()).ToArray();
            HashSet<string> distinctMolecules = new();

            int replacementCount = 0;

            while (molecule != "e")
            {
                bool matchFound = false;

                foreach (string replacement in replacements)
                {
                    string source = replacement.Split(" => ")[0];
                    string destination = replacement.Split(" => ")[1];

                    int position = molecule.IndexOf(destination);

                    if (position != -1)
                    {
                        molecule = $"{molecule.Substring(0, position)}{source}{molecule.Substring(position + destination.Length)}";
                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                {
                    return "Nothing found, try again.";
                }

                replacementCount++;
            }

            return $"The molecule can be created with {replacementCount} replacements.";
        }
    }
}
