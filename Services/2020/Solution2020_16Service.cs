
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2020_16Service: ISolutionDayService{
        public Solution2020_16Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2020_16.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2020_16.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        