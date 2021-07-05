
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2015_19Service: ISolutionDayService{
        public Solution2015_19Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_19.txt"));

            foreach(char character in data){
                
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_19.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        