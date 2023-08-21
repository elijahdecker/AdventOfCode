using System.Text.RegularExpressions;

namespace AdventOfCode.Services
{
    #region Usefull Classes
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }
    #endregion

    // Reminders of useful LINQ functions
    //    * Chunk(n) splits list into list of lists of length n
    //    * Except returns the list of values from the first not in the second
    //    * Intersect returns the list of values in both lists
    //    * Union returns a list of distinct elements between 2 lists
    //    * Zip combine each element of 2 lists 
    //    * Enumerable.Range(a, b) starting at a, increments with each element b times
    //    * Enumerable.Repeat(a, b) repeats a, b times

    /// <summary>
    /// This class holds a handful of custom helper functions to make solving these problems easier
    /// </summary>
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
        /// Splits a string by a given substring
        /// </summary>
        /// <param name="input"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static List<string> SplitSubstring(this string input, string split) {
            return input.Split(split).Where(l => l != split).ToList();
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
        /// Parses a list of list of strings into a list of list of ints
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static List<List<int>> ToInts(this IEnumerable<IEnumerable<string>> strings)
        {
            return strings.Select(ToInts).ToList();
        }

        /// <summary>
        /// Parses a string to a list of ints where each char becomes an int
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> ToInts(this string input) {
            return input.Select(i => i.ToString()).ToInts();
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

        /// <summary>
        /// Mathematical mod (As opposed to C#'s remainder operator '%')
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int Mod(int num, int mod) {
            if (num >= 0) {
                return num % mod;
            }
            else {
                return num + (int)Math.Ceiling((double)Math.Abs(num) / mod) * mod;
            }
        }

        /// <summary>
        /// Mathematical mod (As opposed to C#'s remainder operator '%')
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long Mod(long num, long mod) {
            if (num >= 0) {
                return num % mod;
            }
            else {
                return num + (long)Math.Ceiling((double)Math.Abs(num) / mod) * mod;
            }
        }

        public static IEnumerable<IEnumerable<string>> GetPermutations(this IEnumerable<string> list, int length)
        {
            return length == 1
                ? list.Select(t => new string[] { t })
                : list.GetPermutations(length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new string[] { t2 }));
        }
    }
}