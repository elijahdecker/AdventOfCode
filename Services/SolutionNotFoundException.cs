namespace AdventOfCode.Services
{
    public class SolutionNotFoundException : Exception
    {
        /// <summary>
        /// Thrown when a Solution Service was requested, but none was found.
        /// This could either be an issue with the passed in parameters, or because the file does not exist
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public SolutionNotFoundException(string message) : base(message)
        {
        }
    }
}