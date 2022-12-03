namespace AdventOfCode.Services {
    // Reminders of useful LINQ functions
    // Chunk(n) splits list into list of lists of length n
    // Except returns the list of values from the first not in the second
    // Intersect returns the list of values in both lists
    // Union returns a list of distinct elements between 2 lists
    // Zip combine each element of 2 lists 
    // Enumerable.Range(a, b) starting at a, increments with each element b times
    // Enumerable.Repeat(a, b) repeats a, b times

    public static class Utility {
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
        public static IEnumerable<IEnumerable<T>> ChunkByExclusive<T>(this IEnumerable<T> list, Func<T, bool> predicate)
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
        public static IEnumerable<IEnumerable<T>> ChunkByInclusive<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            return list.ChunkBy(predicate, true);
        }

        private static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> list, Func<T, bool> predicate, bool inclusive)
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
    }
}