# Advent Of Code
This repository serves to hold my own solutions to the [Advent of Code](https://adventofcode.com/).

## Puzzle Helper
This allows you to easily create the needed input files and services.

If you would like to use this project's template for you own solution and inputs
1. First delete the daily service files.
1. Next in the PuzzleHelper folder, create a Cookie.txt file and add your own cookie that gets created when logging into the Advent of Code website. If you open the Network tab in the Dev Tools while on the site you'll see the cookie in the API calls that are made.
1. Finally just run the project and use one of the Puzzle Helper APIs to import your input

The program is idempotent (You can run this multiple times as it will only add files if they are needed.)

## API

### GET api/run-solution
- Query parameters
   - year (Ex. 2022) (Defaults to 2015)
   - day (Ex. 14) (Defaults to 1)
   - secondHalf (Ex. true) (Defaults to false)
   
Runs a specific day's solution, posts the answer to Advent of Code, and returns the result from Advent of Code

### POST api/puzzle-helper

Imports all missing inputs from Advent of Code as well as creating missing solution files.

### POST api/puzzle-helper-daily
- Query parameters
   - year (Ex. 2022)
   - day (Ex. 14)
   
Imports the input from Advent of Code for a specific day. Useful when you want a streamlined version of the above call to only check for a specific day.

## TODO
- Add an option to not post the solution to AoC and just return the result from the puzzle
