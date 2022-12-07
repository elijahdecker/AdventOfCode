# Advent Of Code
This repository serves to hold my own solutions to the [Advent of Code](https://adventofcode.com/).

## Puzzle Helper
This allows you to easily create the needed input files and services.

If you would like to use this project's template for you own solution and inputs
1. First delete the daily service files.
1. Next in the PuzzleHelper folder, create a Cookie.txt file and add your own cookie that gets created when logging into the Advent of Code website. If you open the Network tab in the Dev Tools while on the site you'll see the cookie in the API calls that are made.
1. Finally just run the Puzzle Helper Project.

The program is idempotent (You can run this multiple times as it will only add files if they are needed.)