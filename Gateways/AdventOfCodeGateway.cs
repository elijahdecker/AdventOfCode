using HtmlAgilityPack;

public class AdventOfCodeGateway
{
    private readonly HttpClient client;

    public AdventOfCodeGateway() {
        // Setup the HttpClient for making API calls
        Uri baseAddress = new("https://adventofcode.com");
        using HttpClientHandler handler = new() { UseCookies = false };
        using HttpClient client = new(handler) { BaseAddress = baseAddress };

        // Don't modify this User Agent, it should match the repo making the request and not the user making the request
        client.DefaultRequestHeaders.UserAgent.ParseAdd($".NET 7.0 (+via https://github.com/austin-owensby/AdventOfCode by austin_owensby@hotmail.com)");

        try {
            string cookie = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "PuzzleHelper/Cookie.txt"));
            client.DefaultRequestHeaders.Add("Cookie", cookie);
        }
        catch (Exception) {
            throw new Exception("Unable to read Cookie.txt. Make sure that it exists in the PuzzleHelper folder. See the ReadMe for more.");
        }
        
        this.client = client;
    }

    /// <summary>
    /// For a given year and day, get the user's puzzle input
    /// </summary>
    /// <param name="year"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public async Task<string> ImportInput(int year, int day)
    {
        HttpRequestMessage message = new(HttpMethod.Get, $"/{year}/day/{day}/input");

        HttpResponseMessage result = await client.SendAsync(message);
        string response = await GetSuccessfulResponseContent(result);
        return response;
    }

    /// <summary>
    /// Send the user's answer to the specific question
    /// </summary>
    /// <param name="year"></param>
    /// <param name="day"></param>
    /// <param name="secondHalf"></param>
    /// <param name="answer"></param>
    /// <param name="send"></param>
    /// <returns></returns>
    public async Task<string> SubmitAnswer(int year, int day, bool secondHalf, string answer)
    {
        Dictionary<string, string> data = new()
        {
            { "level", secondHalf ? "2" : "1"},
            { "answer", answer }
        };

        HttpContent request = new FormUrlEncodedContent(data);

        HttpResponseMessage result = await client.PostAsync($"/{year}/day/{day}/answer", request);

        string response = await GetSuccessfulResponseContent(result);

        try
        {
            // Find article component
            HtmlDocument doc = new();
            doc.LoadHtml(response);
            HtmlNode article = doc.DocumentNode.SelectSingleNode("//article/p");
            response = article.InnerHtml;
        }
        catch (Exception)
        {
            Console.WriteLine("Error parsing html response.");
        }

        return response;
    }

    /// <summary>
    /// Ensure that the response was successful and return the parsed response if it was
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    private async Task<string> GetSuccessfulResponseContent(HttpResponseMessage result) {
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadAsStringAsync();
    }
}