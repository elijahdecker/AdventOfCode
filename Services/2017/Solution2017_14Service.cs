
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2017_14Service: ISolutionDayService{
        public Solution2017_14Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2017_14.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2017_14.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        