namespace PuzzleHelper
{
    class Program
    {
        static async Task Main()
        {
            // Server time is UTC-5
            DateTime now = DateTime.UtcNow.AddHours(-5);
            int latestPuzzleYear = now.Year - now.Month == 12 ? 0 : 1;
            int latestPuzzleDay = 25;

            // If we're in December, then the latest available puzzle is today
            if (now.Month == 12)
            {
                latestPuzzleYear = now.Year;
                latestPuzzleDay = now.Day;
            }

            // Startup.cs
            string startupFolderPath = Path.Combine(Environment.CurrentDirectory, "../Startup.cs");

            // Create a folder for each year that is missing one
            for (int year = 2015; year <= latestPuzzleYear; year++)
            {
                string yearFolderPath = Path.Combine(Environment.CurrentDirectory, $"../Services/{year}");

                if (!Directory.Exists(yearFolderPath))
                {
                    Directory.CreateDirectory(yearFolderPath);
                }

                // Create/update files for each day that is missing one
                for (int day = 1; day <= latestPuzzleDay; day++)
                {
                    string dayFilePath = Path.Combine(yearFolderPath, $"Solution{year}_{day:D2}Service.cs");

                    if (!File.Exists(dayFilePath))
                    {
                        // Import the input file
                        string inputFilePath = Path.Combine(Environment.CurrentDirectory, $"../Inputs/{year}_{day:D2}.txt");

                        using StreamWriter inputFile = new(inputFilePath);

                        string response = await ImportInput(year, day);

                        await inputFile.WriteAsync(response);

                        // Update the startup file by adding a new line for injecting the new service
                        string startupFile = await File.ReadAllTextAsync(startupFolderPath);

                        int insertMinIndex = startupFile.IndexOf("services.AddScoped<ISolutionService, SolutionService>();");
                        int insertIndex = startupFile.IndexOf("        }", insertMinIndex);
                        startupFile = startupFile.Insert(insertIndex, $"            services.AddScoped<ISolutionDayService, Solution{year}_{day:D2}Service>();\n");

                        await File.WriteAllTextAsync(startupFolderPath, startupFile);

                        // Initialize the new service file
                        using StreamWriter serviceFile = new(dayFilePath);

                        await serviceFile.WriteAsync($@"using System;
using System.IO;

namespace AdventOfCode.Services
{{
    public class Solution{year}_{day:D2}Service: ISolutionDayService{{
        public Solution{year}_{day:D2}Service(){{}}

        public string FirstHalf(){{
            string[] lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @""Inputs"", ""{year}_{day:D2}.txt""));

            return $"""";
        }}

        public string SecondHalf(){{            
            string[] lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @""Inputs\"", ""{year}_{day:D2}.txt""));

            return $"""";
        }}
    }}
}}
                        ");
                    }
                }
            }
        }

        static async Task<string> ImportInput(int year, int day)
        {
            Uri baseAddress = new("https://adventofcode.com");
            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var message = new HttpRequestMessage(HttpMethod.Get, $"/{year}/day/{day}/input");
                message.Headers.Add("Cookie", "<Insert Cookie Here>");
                var result = await client.SendAsync(message);
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}
