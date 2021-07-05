
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2016_08Service: ISolutionDayService{
        public Solution2016_08Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2016_08.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2016_08.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        