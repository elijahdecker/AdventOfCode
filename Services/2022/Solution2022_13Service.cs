namespace AdventOfCode.Services
{
    public class Solution2022_13Service : ISolutionDayService
    {
        public Solution2022_13Service() { }

        public async Task<string> FirstHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_13.txt")).ToList();

            List<List<string>> packets = lines.ChunkByExclusive(line => string.IsNullOrEmpty(line));

            int answer = 0;

            for (int i = 1; i <= packets.Count; i++)
            {
                List<string> packetPair = packets[i - 1];

                if (ComparePackets(packetPair[0], packetPair[1]) == -1) {
                    answer += i;
                }
            }

            return await Utility.SubmitAnswer(2022, 13, false, answer);
        }

        public async Task<string> SecondHalf()
        {
            List<string> lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "2022_13.txt")).ToList();
            lines = lines.Where(line => !string.IsNullOrEmpty(line)).ToList();
            lines.Add("[[2]]");
            lines.Add("[[6]]");

            lines.Sort((a, b) => ComparePackets(a, b));

            int answer = (lines.IndexOf("[[2]]") + 1) * (lines.IndexOf("[[6]]") + 1);

            return await Utility.SubmitAnswer(2022, 13, true, answer);
        }
    
        private int ComparePackets(string packet1, string packet2) {
            List<string> packet1Elements = new();
            List<string> packet2Elements = new();

            int bracketLevel = packet1.StartsWith('[') ? 0 : 1;
            string currentSignal = string.Empty;
            foreach (char signal in packet1) {
                if (signal == ']') {
                    bracketLevel--;
                }

                if (bracketLevel > 0) {
                    if (signal == ',' && bracketLevel == 1) {
                        packet1Elements.Add(currentSignal);
                        currentSignal = string.Empty;
                    }
                    else {
                        currentSignal += signal;
                    }
                }

                if (signal == '[') {
                    bracketLevel++;
                }
            }
            
            if (!string.IsNullOrEmpty(currentSignal)) {
                packet1Elements.Add(currentSignal);
            }

            bracketLevel = packet1.StartsWith('[') ? 0 : 1;
            currentSignal = string.Empty;
            foreach (char signal in packet2) {
                if (signal == ']') {
                    bracketLevel--;
                }

                if (bracketLevel > 0) {
                    if (signal == ',' && bracketLevel == 1) {
                        packet2Elements.Add(currentSignal);
                        currentSignal = string.Empty;
                    }
                    else {
                        currentSignal += signal;
                    }
                }

                if (signal == '[') {
                    bracketLevel++;
                }
            }
            
            if (!string.IsNullOrEmpty(currentSignal)) {
                packet2Elements.Add(currentSignal);
            }

            int result = 0;

            for (int i = 0; i < Math.Max(packet1Elements.Count, packet2Elements.Count); i++) {
                if (packet1Elements.Count - 1 < i && packet1Elements.Count != packet2Elements.Count) {
                    // Packet 1 has run out first
                    result = -1;
                    break;
                }
                else if (packet2Elements.Count - 1 < i && packet1Elements.Count != packet2Elements.Count) {
                    // Packet 2 has run out first
                    result = 1;
                    break;
                }

                string element1 = packet1Elements[i];
                string element2 = packet2Elements[i];

                bool element1IsNumber = int.TryParse(element1, out int number1);
                bool element2IsNumber = int.TryParse(element2, out int number2);

                // Both elements are numberic, compare the numbers directly
                if (element1IsNumber && element2IsNumber) {
                    if (number1 < number2) {
                        result = -1;
                    }
                    else if (number1 > number2) {
                        result = 1;
                    }
                }

                // One element is a number, the other is a list. Convert the number to a list
                else if (element1IsNumber != element2IsNumber) {
                    if (element1IsNumber) {
                        result = ComparePackets($"[{element1}]", element2);
                    }
                    else {
                        result = ComparePackets(element1, $"[{element2}]");
                    }
                }

                // Both elements are lists, compare them
                else {
                    result = ComparePackets(element1, element2);
                }

                if (result != 0) {
                    break;
                }
            }

            return result;
        }
    }
}