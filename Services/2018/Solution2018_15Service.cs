
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2018_15Service: ISolutionDayService{
        public Solution2018_15Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2018_15.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2018_15.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        