# Advent Of Code
<!--Generated via https://github.com/alexandru-dinu/advent-of-code/blob/main/.scripts/gen_badges.py-->
<!-- begin-year-badge -->
![](https://img.shields.io/badge/2022-30%20stars-517520)
![](https://img.shields.io/badge/2021-20%20stars-6e621d)
![](https://img.shields.io/badge/2020-21%20stars-6b651e)
![](https://img.shields.io/badge/2019-2%20stars-c62917)
![](https://img.shields.io/badge/2018-13%20stars-87521c)
![](https://img.shields.io/badge/2017-0%20stars-ef0f14)
![](https://img.shields.io/badge/2016-0%20stars-ef0f14)
![](https://img.shields.io/badge/2015-44%20stars-308b22)
<!-- end-year-badge -->
This repository serves to hold my own solutions to the [Advent of Code](https://adventofcode.com/).
Feel free to copy this template and generate your own solutions

## Puzzle Helper
This allows you to easily create the needed input files and services.

If you would like to use this project's template for you own solution and inputs
1. First delete the daily service files.
1. Next in the PuzzleHelper folder, create a Cookie.txt file and add your own cookie that gets created when logging into the Advent of Code website. If you open the Network tab in the Dev Tools while on the site you'll see the cookie in the API calls that are made.
1. Finally just run the project and use the Puzzle Helper API (`POST api/puzzle-helper`) to import your inputs and create fresh services

The program is idempotent (You can run this multiple times as it will only add files if they are needed.)

## API

### GET api/run-solution
- Query parameters
- year (Ex. 2022) (Defaults to 2015)
- day (Ex. 14) (Defaults to 1)
- secondHalf (Ex. true) (Defaults to false)
- send (Ex. true) (Defaults to false)

Runs a specific day's solution, posts the answer to Advent of Code, and returns the result from Advent of Code

### POST api/puzzle-helper

Imports all missing inputs from Advent of Code as well as creating missing solution files.

### POST api/puzzle-helper-daily
- Query parameters
- year (Ex. 2022) (Defaults to 2015)
- day (Ex. 14) (Defaults to 1)

Imports the input from Advent of Code for a specific day. Useful when you want a streamlined version of the above call to only check for a specific day.

## Extra Notes
- The admin of Advent of Code have requested that puzzle inputs be cached (To reduce load on the system) and not be made publically available (To make it harder to completely copy the site)
- This puzzle helper currently does not use the leaderboard api, but if you choose to copy this template and talk to the leaderboard, make sure to throttle the and cache the calls to not overload the server

## TODO
- Add an easy way to switch between the example and real input
