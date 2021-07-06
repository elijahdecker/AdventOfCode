using System;
namespace AdventOfCode.Services
{
    public class SolutionNotFoundException: Exception{
        public SolutionNotFoundException(string message): base(message){
        }
    }
}