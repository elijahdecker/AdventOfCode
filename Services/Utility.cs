using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace AdventOfCode.Services
{
    // Reminders of useful LINQ functions
    // Chunk(n) splits list into list of lists of length n
    // Except returns the list of values from the first not in the second
    // Intersect returns the list of values in both lists
    // Union returns a list of distinct elements between 2 lists
    // Zip combine each element of 2 lists 
    // Enumerable.Range(a, b) starting at a, increments with each element b times
    // Enumerable.Repeat(a, b) repeats a, b times

    public static class Utility
    {
        /// <summary>
        /// Converts 'a' to 1 and 'A' to 27
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetCharValue(this char value)
        {
            int asciiValue = value;

            int offset = char.IsLower(value) ? 'a' - 1 : 'A' - 27;

            return asciiValue - offset;
        }

        /// <summary>
        /// Chunks a list based on a predicate. The element that matches the predicate is not included in a chunk 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<List<T>> ChunkByExclusive<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            return list.ChunkBy(predicate, false);
        }

        /// <summary>
        /// Chunks a list based on a predicate. The element that matches the predicate is included in the current chunk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<List<T>> ChunkByInclusive<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            return list.ChunkBy(predicate, true);
        }

        private static List<List<T>> ChunkBy<T>(this IEnumerable<T> list, Func<T, bool> predicate, bool inclusive)
        {
            List<List<T>> resultList = new();
            List<T> result = new();

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    if (inclusive)
                    {
                        result.Add(item);
                    }

                    resultList.Add(result);
                    result = new();
                }
                else
                {
                    result.Add(item);
                }
            }

            // Add the last chunk if needed
            if (result.Any())
            {
                resultList.Add(result);
            }

            return resultList;
        }

        /// <summary>
        /// A quick version of regex that assumes we're receiving 1 line and only want the first match
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static List<string> QuickRegex(this string input, string regex)
        {
            List<string> response = new();

            Regex rx = new(regex);

            MatchCollection match = rx.Matches(input);

            if (match.Any())
            {
                GroupCollection groups = match.First().Groups;

                // Not starting at i = 0 because that returns the whole match, we only care about the captures
                for (int i = 1; i < groups.Count; i++)
                {
                    Group group = groups[i];

                    response.Add(group.Value);
                }
            }

            return response;
        }

        /// <summary>
        /// A quick version of regex that assumes that each element of the list is 1 line and only want the first match
        /// </summary>
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static List<List<string>> QuickRegex(this IEnumerable<string> input, string regex)
        {
            return input.Select(i => i.QuickRegex(regex)).ToList();
        }

        /// <summary>
        /// Parses a list of strings into a list of ints
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static List<int> ToInts(this IEnumerable<string> strings)
        {
            return strings.Select(int.Parse).ToList();
        }

        /// <summary>
        /// Parses a list of strings into a list of longs
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static List<long> ToLongs(this IEnumerable<string> strings)
        {
            return strings.Select(long.Parse).ToList();
        }

        /// <summary>
        /// Returns the answer as a string by default
        /// If send is set to true, submits the answer to Advent of Code and returns the response
        /// </summary>
        /// <param name="year"></param>
        /// <param name="day"></param>
        /// <param name="secondHalf"></param>
        /// <param name="answer"></param>
        /// <param name="send"></param>
        /// <returns></returns>
        public static async Task<string> SubmitAnswer<T>(int year, int day, bool secondHalf, T answer, bool send = false)
        {
            return await PostAnswer(year, day, secondHalf, answer.ToString());
        }

        private static async Task<string> PostAnswer(int year, int day, bool secondHalf, string answer, bool send = false)
        {
            string reponse = string.Empty;

            if (send)
            {
                Uri baseAddress = new("https://adventofcode.com");
                using HttpClientHandler handler = new() { UseCookies = false };
                using HttpClient client = new(handler) { BaseAddress = baseAddress };
                
                // Don't modify this User Agent, it should match the repo making the request and not the user making the request
                client.DefaultRequestHeaders.UserAgent.ParseAdd($".NET 7.0 (+via https://github.com/austin-owensby/AdventOfCode by austin_owensby@hotmail.com)");

                string cookie = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "PuzzleHelper/Cookie.txt"));
                client.DefaultRequestHeaders.Add("Cookie", cookie);

                Dictionary<string, string> data = new(){
                        { "level", secondHalf ? "2" : "1"},
                        { "answer", answer }
                    };

                HttpContent request = new FormUrlEncodedContent(data);

                HttpResponseMessage result = await client.PostAsync($"/{year}/day/{day}/answer", request);

                result.EnsureSuccessStatusCode();
                reponse = await result.Content.ReadAsStringAsync();

                try
                {
                    // Find article component
                    HtmlDocument doc = new();
                    doc.LoadHtml(reponse);
                    HtmlNode article = doc.DocumentNode.SelectSingleNode("//article/p");
                    reponse = article.InnerHtml;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error parsing html response.");
                }
            }
            else
            {
                reponse = answer;
            }

            return reponse;
        }

        /// <summary>
        /// Pivot's a 2D list
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<List<T>> Pivot<T>(this IEnumerable<IEnumerable<T>> list)
        {
            return list
                .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => g.ToList())
                .ToList();
        }

        /// <summary>
        /// Reverses a list in place
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ReverseInPlace<T>(this List<T> list)
        {
            list.Reverse();

            return list.ToList();
        }
    }
}