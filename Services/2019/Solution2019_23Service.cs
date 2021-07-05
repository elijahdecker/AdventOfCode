
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2019_23Service: ISolutionDayService{
        public Solution2019_23Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_23.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_23.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        