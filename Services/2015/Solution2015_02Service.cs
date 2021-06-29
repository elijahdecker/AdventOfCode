using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace AdventOfCode.Services
{
    public class Solution2015_02Service: ISolutionDayService{
        public Solution2015_02Service(){}

        public string FirstHalf(){
            int total = 0;

            // Read file contents
            string line;

            StreamReader file = new StreamReader(Path.Combine(Environment.CurrentDirectory,@"Inputs\", "2015_02.txt"));  
            while((line = file.ReadLine()) != null)  
            {
                // Get dimensions of the box
                List<int> dimensions = line.Split('x').Select(size => Int32.Parse(size)).ToList();

                int length = dimensions[0];
                int width = dimensions[1];
                int height = dimensions[2];

                // Find min area of side
                int minArea = new List<int>(){length* width, length*height, width*height}.Min();

                // Calculate the used surface area
                int surfaceArea = 2*(length*width + length*height + width*height) + minArea;

                total += surfaceArea;
            }  

            return $"Total area of wrapping paper needed: {total} ft^2.";
        }

        public string SecondHalf(){
            int total = 0;

            // Read file contents
            string line;

            StreamReader file = new StreamReader(Path.Combine(Environment.CurrentDirectory,@"Inputs\", "2015_02.txt"));  
            while((line = file.ReadLine()) != null)  
            {
                // Get dimensions of the box
                List<int> dimensions = line.Split('x').Select(size => Int32.Parse(size)).ToList();

                int length = dimensions[0];
                int width = dimensions[1];
                int height = dimensions[2];

                // Find min perimeter of side
                int minPerimeter = new List<int>(){2 *(length + width), 2 * (length + height), 2 * (width + height)}.Min();

                // Calculate the used surface area
                int surfaceArea = length*width*height + minPerimeter;

                total += surfaceArea;
            }  

            return $"Total area of ribbon needed: {total} ft^2.";
        }
    }
}