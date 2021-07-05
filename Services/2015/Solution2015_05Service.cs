
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public class Solution2015_05Service: ISolutionDayService{
        public Solution2015_05Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_05.txt"));
            string[] lines = data.Split("\n");
            char[] vowels = new char[]{'a', 'e', 'i', 'o', 'u'};
            string[] invalidStrings = new string[]{"ab", "cd", "pq", "xy"};

            int niceCount = 0;

            foreach(string line in lines){
                // Check for 3 vowels
                if(line.Count(c => vowels.Contains(c)) >= 3){
                    // Check for 2 of the same char in a row
                    char previousChar = ' ';
                    bool duplicateFound = false;

                    foreach(char currentChar in line){
                        if(currentChar == previousChar){
                            duplicateFound = true;
                            break;
                        }

                        previousChar = currentChar;
                    }

                    if(duplicateFound){
                        bool invalidStringFound = false;
                        foreach(string invalidString in invalidStrings){
                            if(line.Contains(invalidString)){
                                invalidStringFound = true;
                                break;
                            }
                        }

                        if(!invalidStringFound){
                            niceCount++;
                        }
                    }
                }
            }

            return $"There are {niceCount} nice strings.";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_05.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        