public class PuzzleHelperService : IPuzzleHelperService
{
    public PuzzleHelperService() { }

    /// <summary>
    /// Generates solution files and imports year input files
    /// </summary>
    /// <returns></returns>
    public async Task<string> Run()
    {
        string output = string.Empty;

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
        else
        {
            // Otherwise the latest puzzle is from the end of the previous event
            latestPuzzleYear = now.Year - 1;
            latestPuzzleDay = 25;
        }

        bool update = false;

        // Create a folder for each year that is missing one
        for (int year = 2015; year <= now.Year; year++)
        {
            string yearFolderPath = Path.Combine(Environment.CurrentDirectory, $"Services/{year}");

            if (!Directory.Exists(yearFolderPath))
            {
                Directory.CreateDirectory(yearFolderPath);
                Console.WriteLine($"Created folder for {year}.");
                output += $"Created folder for {year}.";
                update = true;
            }

            // Create/update files for each day that is missing one
            for (int day = 1; day <= 25; day++)
            {
                string dayFilePath = Path.Combine(yearFolderPath, $"Solution{year}_{day:D2}Service.cs");

                if (!File.Exists(dayFilePath))
                {
                    // Initialize the new service file
                    using StreamWriter serviceFile = new(dayFilePath);

                    await serviceFile.WriteAsync($$"""
        namespace AdventOfCode.Services
        {
            public class Solution{{year}}_{{day:D2}}Service : ISolutionDayService
            {
                public Solution{{year}}_{{day:D2}}Service() { }

                public async Task<string> FirstHalf(bool send)
                {
                    List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "{{year}}_{{day:D2}}.txt")).ToList();

                    int answer = 0;

                    foreach (string line in lines) {

                    }

                    return await Utility.SubmitAnswer({{year}}, {{day}}, false, answer, send);
                }

                public async Task<string> SecondHalf(bool send)
                {
                    List<string> lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "{{year}}_{{day:D2}}.txt")).ToList();

                    int answer = 0;

                    foreach (string line in lines) {

                    }

                    return await Utility.SubmitAnswer({{year}}, {{day}}, true, answer, send);
                }
            }
        }
        """);

                    Console.WriteLine($"Created solution file for Year: {year}, Day: {day}.");
                    output += $"Created solution file for Year: {year}, Day: {day}.";
                    update = true;
                }

                // Only import the file if it is available
                if (year < latestPuzzleYear || (year == latestPuzzleYear && day <= latestPuzzleDay))
                {
                    string inputFilePath = Path.Combine(Environment.CurrentDirectory, $"Inputs/{year}_{day:D2}.txt");

                    if (!File.Exists(inputFilePath))
                    {
                        using StreamWriter inputFile = new(inputFilePath);

                        string response = await ImportInput(year, day);

                        await inputFile.WriteAsync(response);

                        Console.WriteLine($"Created input file for Year: {year}, Day: {day}.");
                        output += $"Created input file for Year: {year}, Day: {day}.";
                        update = true;
                    }
                }
            }
        }

        if (!update)
        {
            Console.WriteLine("No updates applied.");
            output += "No updates applied.";
        }

        return output;
    }

    /// <summary>
    /// A streamlined version of the puzzle helper that imports just the days file
    /// </summary>
    /// <param name="year"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public async Task<string> RunDaily(int year, int day)
    {
        string output = string.Empty;

        string inputFilePath = Path.Combine(Environment.CurrentDirectory, $"Inputs/{year}_{day:D2}.txt");

        if (!File.Exists(inputFilePath))
        {
            using StreamWriter inputFile = new(inputFilePath);

            string response = await ImportInput(year, day);

            await inputFile.WriteAsync(response);

            Console.WriteLine($"Created input file for Year: {year}, Day: {day}.");
            output = $"Created input file for Year: {year}, Day: {day}.";
        }
        else
        {
            Console.WriteLine("No updates applied.");
            output += "No updates applied.";
        }

        return output;
    }

    private async Task<string> ImportInput(int year, int day)
    {
        Uri baseAddress = new("https://adventofcode.com");
        using HttpClientHandler handler = new() { UseCookies = false };
        using HttpClient client = new(handler) { BaseAddress = baseAddress };
        client.DefaultRequestHeaders.UserAgent.ParseAdd($".NET 7.0 (+via https://github.com/austin-owensby/AdventOfCode by austin_owensby@hotmail.com)");

        HttpRequestMessage message = new(HttpMethod.Get, $"/{year}/day/{day}/input");

        string cookie = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "PuzzleHelper/Cookie.txt"));
        message.Headers.Add("Cookie", cookie);

        HttpResponseMessage result = await client.SendAsync(message);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadAsStringAsync();
    }
}
