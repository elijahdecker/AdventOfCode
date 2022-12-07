public interface IPuzzleHelperService {
    Task<string> Run();
    Task<string> RunDaily(int year, int day);
}