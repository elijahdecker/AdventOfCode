
using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode.Services
{
    public class Solution2015_12Service: ISolutionDayService{
        public Solution2015_12Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_12.txt"));

            int sum = 0;
            List<char> validNumberCharacters = new(){'-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            string trackedNumber = "";

            foreach(char character in data){
                if(validNumberCharacters.Contains(character)){
                    trackedNumber += character;
                }
                else if(trackedNumber != ""){
                    sum += Int32.Parse(trackedNumber);
                    trackedNumber = "";
                }
            }

            return $"The sum of all the numbers in the document is {sum}.";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_12.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        