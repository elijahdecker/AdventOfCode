namespace AdventOfCode.Services
{
    public class SolutionService : ISolutionService
    {
        private readonly IServiceProvider serviceProvider;

        public SolutionService(IServiceProvider serviceProvider, ISolutionDayService solutionDayService)
        {
            this.serviceProvider = serviceProvider;
        }

        public string GetSolution(int year, int day, bool secondHalf)
        {
            // Fetch the specific service
            IEnumerable<ISolutionDayService> services = serviceProvider.GetServices<ISolutionDayService>();
            ISolutionDayService service = services.FirstOrDefault(s => s.GetType().ToString() == $"AdventOfCode.Services.Solution{year}_{day:D2}Service");

            // If the service was not found, throw an exception
            if (service == null)
            {
                throw new SolutionNotFoundException($"No solutions found for day {day}/{year}.");
            }

            // Get the specific solutino
            return secondHalf ? service.SecondHalf() : service.FirstHalf();
        }

        public async Task<bool> SendSolution(int year, int day, bool secondHalf) {
            string answer = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Outputs", $"{year}_{day:D2}_{(secondHalf ? 2 : 1)}.txt"));
        
            Uri baseAddress = new("https://adventofcode.com");
            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd($".NET 7.0 (+via https://github.com/austin-owensby/AdventOfCode by austin_owensby@hotmail.com)");

                string cookie = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "PuzzleHelper/Cookie.txt"));
                client.DefaultRequestHeaders.Add("Cookie", cookie);

                Dictionary<string, string> data = new(){
                    { "level", secondHalf ? "2" : "1"},
                    { "answer", answer }
                };

                HttpContent request = new FormUrlEncodedContent(data);

                var result = await client.PostAsync($"/{year}/day/{day}/answer", request);

                result.EnsureSuccessStatusCode();
                string content = await result.Content.ReadAsStringAsync();

                Console.Clear();
                // For debugging in case we get an unexpected output
                Console.Write(content);

                if (content.Contains("That's not the right answer")) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    }
}