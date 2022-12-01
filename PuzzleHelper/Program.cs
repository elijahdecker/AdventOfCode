namespace PuzzleHelper
{
    class Program
    {
        static async Task Main()
        {
            // Server time is UTC-5
            DateTime now = DateTime.UtcNow.AddHours(-5);
            int latestPuzzleYear, latestPuzzleDay;

            // If we're in December, then the latest available puzzle is today
            if (now.Month == 12)
            {
                latestPuzzleYear = now.Year;

                // If it's December 26th-31st the latest day is the 25th
                latestPuzzleDay = Math.Min(now.Day, 25);
            }
            else {
                // Otherwise the latest puzzle is from the end of the previous event
                latestPuzzleYear = now.Year - 1;
                latestPuzzleDay = 25;
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

                        await serviceFile.WriteAsync($$"""
namespace AdventOfCode.Services
{
    public class Solution{{year}}_{{day:D2}}Service: ISolutionDayService{
        public Solution{{year}}_{{day:D2}}Service(){}

        public string FirstHalf(){
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "{{year}}_{{day:D2}}.txt")).ToList();

            return $"";
        }

        public string SecondHalf(){
            List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "{{year}}_{{day:D2}}.txt")).ToList();

            return $"";
        }
    }
}
""");
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
                message.Headers.Add("Cookie", "_ga=GA1.2.2025053948.1667698880; session=53616c7465645f5fc7c26110549b8c17fb43c5ad58369985e83b3775382993395b90b83c6f702d048717586fa3b15af396b3de0a51e4df8282debdd55f992403; _gid=GA1.2.1015458013.1669854031");
                var result = await client.SendAsync(message);
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}
