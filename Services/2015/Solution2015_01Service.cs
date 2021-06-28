using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2015_01Service: ISolutionDayService{
        public Solution2015_01Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs\", "2015_01.txt"));

            int floor = 0;

            foreach(char character in data){
                if(character == '('){
                    floor++;
                }
                else if(character == ')'){
                    floor--;
                }
            }

            return $"Santa's final floor: {floor}.";
        }

        public string SecondHalf(){
            return "Solution day 1 part 2";
        }
    }
}