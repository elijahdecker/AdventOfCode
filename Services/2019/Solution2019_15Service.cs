
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2019_15Service: ISolutionDayService{
        public Solution2019_15Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_15.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2019_15.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        