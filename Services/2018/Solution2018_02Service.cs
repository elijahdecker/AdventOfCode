using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public class Solution2018_02Service: ISolutionDayService{
        public Solution2018_02Service(){}

        public string FirstHalf(){
            string[] lines =  File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2018_02.txt"));

            int twiceCount = 0;
            int thriceCount = 0;

            foreach(string line in lines){
                bool twoPairFound = false;
                bool threePairFound = false;

                for (int i = 0; i < line.Length - 1; i++){
                    char letter = line[i];

                    if (!twoPairFound){
                        if (line.Count(l => l == letter) == 2){
                            twoPairFound = true;
                            twiceCount++;
                        }
                    }

                    if (!threePairFound){
                        if (line.Count(l => l == letter) == 3){
                            threePairFound = true;
                            thriceCount++;
                        }
                    }

                    if (twoPairFound && threePairFound)
                    {
                        break;
                    }
                }
            }

            int checksum = twiceCount * thriceCount;

            return $"The checksum is {checksum}";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2018_02.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        