
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2016_17Service: ISolutionDayService{
        public Solution2016_17Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2016_17.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2016_17.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        