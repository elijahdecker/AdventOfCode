using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public class Solution2015_07Service: ISolutionDayService{
        public Solution2015_07Service(){}

        public string FirstHalf(){
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_07.txt"));
            string[] lines = data.Split("\n");
            List<string> knownRegisters = new();
            Dictionary<string, ushort> registerValues = new();
            Dictionary<List<string>, string> unknownRegisters = new();

            // Process the data from the file into unknown and known registers
            foreach(string line in lines){
               string[] instruction = line.Split(" ");

                // # -> a
               if(instruction.Length == 3){
                   knownRegisters.Add(instruction[2]);
                   registerValues[instruction[2]] = UInt16.Parse(instruction[0]);
               }

                // NOT a -> b
               if(instruction.Length == 4){
                   unknownRegisters[new List<string>{instruction[0], instruction[1]}] = instruction[3];
               }

               // a AND b -> c
               // 1 AND a -> b
               // a OR b -> c
               // a LSHIFT 1 -> b
               // a RSHIFT 1 -> b
               if(instruction.Length == 5){
                   if(instruction[1] == "AND"){
                        unknownRegisters[new List<string>{instruction[1], instruction[0], instruction[2]}] = instruction[4];
                   }
                   else if(instruction[1] == "OR"){
                        unknownRegisters[new List<string>{instruction[1], instruction[0], instruction[2]}] = instruction[4];
                   }
                   else if(instruction[1] == "LSHIFT"){
                        unknownRegisters[new List<string>{instruction[1], instruction[0], instruction[2]}] = instruction[4];
                   }
                   else if(instruction[1] == "RSHIFT"){
                        unknownRegisters[new List<string>{instruction[1], instruction[0], instruction[2]}] = instruction[4];
                   }
               }
            }

            foreach(KeyValuePair<List<string>, string> pair in unknownRegisters){
                // Get the arguments for the registers for this instruction
                List<string> registers = pair.Key.Count == 3 ? new List<string>(){pair.Key[1], pair.Key[2]} : new List<string>{pair.Key[1]};

                // If the registers for this instruction are all known, calculate the new value
                if(knownRegisters.Intersect(registers).Any()){

                }
            }

            return $"";
        }

        public string SecondHalf(){            
            string data =  File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Inputs", "2015_07.txt"));

            foreach(char character in data){

            }

            return $"";
        }
    }
}
                        