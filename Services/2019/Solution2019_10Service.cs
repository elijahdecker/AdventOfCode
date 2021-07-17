using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2019_10Service: ISolutionDayService{
        public Solution2019_10Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_10.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_10.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        