namespace AdventOfCode.Services
{
    public class SolutionService : ISolutionService
    {
        private readonly IServiceProvider serviceProvider;

        public SolutionService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Execute the specific solution by finding the day's solution service
        /// </summary>
        /// <param name="year"></param>
        /// <param name="day"></param>
        /// <param name="secondHalf"></param>
        /// <param name="send"></param>
        /// <returns></returns>
        /// <exception cref="SolutionNotFoundException"></exception>
        public async Task<string> GetSolution(int year, int day, bool secondHalf, bool send)
        {
            // Fetch the specific service
            IEnumerable<ISolutionDayService> services = serviceProvider.GetServices<ISolutionDayService>();
            ISolutionDayService service = services.FirstOrDefault(s => s.GetType().ToString() == $"AdventOfCode.Services.Solution{year}_{day:D2}Service");

            // If the service was not found, throw an exception
            if (service == null)
            {
                throw new SolutionNotFoundException($"No solutions found for day {day}/{year}.");
            }

            // Get the specific solution
            return secondHalf ? await service.SecondHalf(send) : await service.FirstHalf(send);
        }
    }
}