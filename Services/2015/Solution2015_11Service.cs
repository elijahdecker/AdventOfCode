namespace AdventOfCode.Services
{
    public class Solution2015_11Service : ISolutionDayService
    {
        public Solution2015_11Service() { }

        public string FirstHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_11.txt"));

            string currentPassword = data.Split('\n')[0];

            char[] invalidLetters = new char[] { 'i', 'o', 'l' };

            while (true)
            {
                currentPassword = incrementPassword(currentPassword);

                // Cannot contain the letters 'i', 'o', or 'l'
                if (!currentPassword.Intersect(invalidLetters).Any())
                {
                    bool sequenceFound = false;

                    // Find a sequence of 3 consecuitve letters
                    for (int i = 0; i < currentPassword.Length - 2; i++)
                    {
                        if ((int)currentPassword[i] + 1 == (int)currentPassword[i + 1] && (int)currentPassword[i] + 2 == (int)currentPassword[i + 2])
                        {
                            sequenceFound = true;
                            break;
                        }
                    }

                    if (sequenceFound)
                    {
                        bool bothPairsFound = false;
                        bool firstPairFound = false;
                        int firstPairsIndex = 0;

                        // Find 2 pairs of duplciate letters
                        for (int i = 0; i < currentPassword.Length - 1; i++)
                        {
                            if (currentPassword[i] == currentPassword[i + 1])
                            {
                                if (firstPairFound)
                                {
                                    // Don't allow pairs to overlap
                                    if (i == firstPairsIndex + 1)
                                    {
                                        continue;
                                    }
                                    bothPairsFound = true;
                                }
                                else
                                {
                                    firstPairsIndex = i;
                                    firstPairFound = true;
                                }
                            }
                        }

                        if (bothPairsFound)
                        {
                            break;
                        }
                    }
                }
            }

            return $"Santa's next password should be \"{currentPassword}\".";
        }

        public string SecondHalf()
        {
            string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_11.txt"));

            string currentPassword = data.Split('\n')[0];

            char[] invalidLetters = new char[] { 'i', 'o', 'l' };

            bool firstPasswordFound = false;

            while (true)
            {
                currentPassword = incrementPassword(currentPassword);

                // Cannot contain the letters 'i', 'o', or 'l'
                if (!currentPassword.Intersect(invalidLetters).Any())
                {
                    bool sequenceFound = false;

                    // Find a sequence of 3 consecuitve letters
                    for (int i = 0; i < currentPassword.Length - 2; i++)
                    {
                        if ((int)currentPassword[i] + 1 == (int)currentPassword[i + 1] && (int)currentPassword[i] + 2 == (int)currentPassword[i + 2])
                        {
                            sequenceFound = true;
                            break;
                        }
                    }

                    if (sequenceFound)
                    {
                        bool bothPairsFound = false;
                        bool firstPairFound = false;
                        int firstPairsIndex = 0;

                        // Find 2 pairs of duplciate letters
                        for (int i = 0; i < currentPassword.Length - 1; i++)
                        {
                            if (currentPassword[i] == currentPassword[i + 1])
                            {
                                if (firstPairFound)
                                {
                                    // Don't allow pairs to overlap
                                    if (i == firstPairsIndex + 1)
                                    {
                                        continue;
                                    }
                                    bothPairsFound = true;
                                }
                                else
                                {
                                    firstPairsIndex = i;
                                    firstPairFound = true;
                                }
                            }
                        }

                        if (bothPairsFound)
                        {
                            // Find the second valid password
                            if (firstPasswordFound)
                            {
                                break;
                            }
                            else
                            {
                                firstPasswordFound = true;
                            }
                        }
                    }
                }
            }

            return $"Santa's next password should be \"{currentPassword}\".";
        }


        private string incrementPassword(string input)
        {
            int[] array = input.ToCharArray().Select(c => (int)c).ToArray();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == (int)'z')
                {
                    array[i] = (int)'a';
                }
                else
                {
                    ++array[i];
                    break;
                }
            }

            return new string(array.Select(a => (char)a).ToArray());
        }
    }
}
