
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2015_07Service: ISolutionDayService{
        public Solution2015_07Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_07.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_07.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        