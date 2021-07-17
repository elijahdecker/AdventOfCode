using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2019_20Service: ISolutionDayService{
        public Solution2019_20Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_20.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_20.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        