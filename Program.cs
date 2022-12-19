﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // support advanced unicode characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Battle Boats (c) S104 Productions 2001-2023");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
            while (true)
            {
                // Output the menu options
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your menu choice: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("1 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Start new game\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("2 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Resume game\n");
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("3 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("View instructions\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("4 - ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Exit program\n\n");


                // Ask for the menu option
                Console.ForegroundColor = ConsoleColor.Blue;
                string menuOption = Console.ReadLine();
                // Perform a subroutine based on the menu option
                switch (menuOption) 
                {
                    case "1":

                        LoadingAnimation();
                        CreateBaseGrid();
                        
                        Console.Write("\nPlease enter the coordinates of your ships in ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("x,y ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("format.\n\n");
                        Console.ForegroundColor = ConsoleColor.Blue;


                        // get input of first coordinates and split characters into array
                        string coordinate1 = Console.ReadLine();
                        string[] coordinatearray1 = coordinate1.Split(',');
                        // initialize new integer array and convert the string array to int array
                        int arrsize1 = coordinatearray1.Length;
                        int[] intcoords1 = new int[arrsize1];
                        for(int i = 0; i < arrsize1; i++)
                        {
                            intcoords1[i] = Int32.Parse(coordinatearray1[i]);
                        }
                        //Console.WriteLine(intcoords1);

                        // Repeat 2
                        string coordinate2 = Console.ReadLine();
                        string[] coordinatearray2 = coordinate2.Split(',');
                        int arrsize2 = coordinatearray2.Length;
                        int[] intcoords2 = new int[arrsize2];
                        for(int i = 0; i < arrsize2; i++) intcoords2[i] = Int32.Parse(coordinatearray2[i]);
                        
                        // Repeat 3
                        string coordinate3 = Console.ReadLine();
                        string[] coordinatearray3 = coordinate3.Split(',');
                        int arrsize3 = coordinatearray3.Length;
                        int[] intcoords3 = new int[arrsize3];
                        for(int i = 0; i < arrsize3; i++) intcoords3[i] = Int32.Parse(coordinatearray3[i]);
                        
                        // Repeat 4
                        string coordinate4 = Console.ReadLine();
                        string[] coordinatearray4 = coordinate4.Split(',');
                        int arrsize4 = coordinatearray4.Length;
                        int[] intcoords4 = new int[arrsize4];
                        for(int i = 0; i < arrsize4; i++) intcoords4[i] = Int32.Parse(coordinatearray4[i]);

                        // Repeat 5
                        string coordinate5 = Console.ReadLine();
                        string[] coordinatearray5 = coordinate5.Split(',');
                        int arrsize5 = coordinatearray5.Length;
                        int[] intcoords5 = new int[arrsize5];
                        for(int i = 0; i < arrsize5; i++) intcoords5[i] = Int32.Parse(coordinatearray5[i]);
                         
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nYour coordinates are displayed as follows:\n");
                        
                        // create 2d array to display updated grid
                        string[,] primarygrid = new string[8, 8]
                        {
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."},
                            {".", ".", ".", ".", ".", ".", ".", "."}
                        };
                        
                        string[,] secondarygrid = new string[8, 8];
                        Array.Copy(primarygrid, secondarygrid, primarygrid.Length);

                        // edit user defined locations of array and mark it
                        Console.ForegroundColor = ConsoleColor.Red;
                        primarygrid[intcoords1[0] - 1, intcoords1[1] - 1] = "▢";
                        primarygrid[intcoords2[0] - 1, intcoords2[1] - 1] = "▢";
                        primarygrid[intcoords3[0] - 1, intcoords3[1] - 1] = "▢";
                        primarygrid[intcoords4[0] - 1, intcoords4[1] - 1] = "▢";
                        primarygrid[intcoords5[0] - 1, intcoords5[1] - 1] = "▢";

                        // looping through array
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" 1 2 3 4 5 6 7 8");
                        for (int i = 0; i < 8; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(i + 1);
                            for (int j = 0; j < 8; j++)
                            {
                                // loop through and print all elements of 2d array
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write($"{primarygrid[i, j]} ");
                            }
                            // new line between each row
                            ResetColors();
                            Console.WriteLine("");
                        }

                        // new line to clear coloring
                        ResetColors();
                        Console.WriteLine("");

                        // generate computer's coordinates
                        Random computervalues = new Random();
                        int[] computercoords1 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords2 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords3 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords4 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};
                        int[] computercoords5 = {computervalues.Next(1, 9), computervalues.Next(1, 9)};

                        /*for (int i = 0; i < computercoords1.Length; i++)
                        {
                            Console.WriteLine(computercoords1[i]);
                            Console.WriteLine(computercoords2[i]);
                            Console.WriteLine(computercoords3[i]);
                            Console.WriteLine(computercoords4[i]);
                            Console.WriteLine(computercoords5[i]);
                        }*/

                        int userguesses = 0;
                        int computerguesses = 0;
                        bool gamedone = false;

                        do
                        {
                            Thread.Sleep(500);
                            string userguess = "";
                            // user guess
                            string pattern = @"^\d+,\d+$";
                            Regex regex = new Regex(pattern);

                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\nGuess the location of a computer's ship in ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("x,y ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("format.\n\n");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                
                                userguess = Console.ReadLine();
                                string[] uservalidator = userguess.Split(',');
                                
                                if (regex.IsMatch(userguess) && Convert.ToInt32(uservalidator[0]) > 1 && Convert.ToInt32(uservalidator[0]) < 8 && Convert.ToInt32(uservalidator[1]) > 1 && Convert.ToInt32(uservalidator[1]) < 8)
                                {
                                    // userguess is in x, y format and is inside bounds
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    int tryint;
                                    if (!regex.IsMatch(userguess) || Int32.TryParse(uservalidator[0], out tryint) || Int32.TryParse(uservalidator[1], out tryint)) Console.WriteLine("Error: Bad input string");
                                    if (Convert.ToInt32(uservalidator[0]) > 8 || Convert.ToInt32(uservalidator[0]) < 1 || Convert.ToInt32(uservalidator[1]) > 8 && Convert.ToInt32(uservalidator[1]) < 1) Console.WriteLine("Error: Input string was out of bounds");
                                }
                            }

                            // split the user guess into an array
                            string[] userguessarray = userguess.Split(',');

                            int[] userguessint = new int[2];


                            //check if hit with abnormally big statement

                            for(int i = 0; i < 2; i++) userguessint[i] = Int32.Parse(userguessarray[i]);
                            if ((userguessint[0] == computercoords1[0] && userguessint[1] == computercoords1[1]) || (userguessint[0] == computercoords2[0] && userguessint[1] == computercoords2[1]) || (userguessint[0] == computercoords3[0] && userguessint[1] == computercoords3[1]) || (userguessint[0] == computercoords4[0] && userguessint[1] == computercoords4[1]) || (userguessint[0] == computercoords5[0] && userguessint[1] == computercoords5[1]))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You hit one of the computer's ships!\n");
                                userguesses += 1;
                                Thread.Sleep(1000);
                                // re print grid with a H on the place hit
                                secondarygrid[userguessint[1] - 1, userguessint[0] - 1] = "H";
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{primarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{secondarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You missed your shot.\n");

                                Thread.Sleep(1000);

                                // re print grid with a M on the place hit
                                secondarygrid[userguessint[1] - 1, userguessint[0] - 1] = "M";
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{primarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{secondarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }
                            }



















                            // generate random computer guess coordinates
                            Random r = new Random();
                            int[] computerguess = new int[2];

                            // assign random computer value
                            computerguess[0] = r.Next(1, 9);
                            computerguess[1] = r.Next(1, 9);

                            Console.WriteLine($"{computerguess[0]} {computerguess[1]} ");

                            // check if the computer has hit a previously referenced position, and if so then generate new coordinates. if not then continue
                            while ((primarygrid[computerguess[0], computerguess[1]] == "▢") || (primarygrid[computerguess[0], computerguess[1]] == "M") || (primarygrid[computerguess[0], computerguess[1]] == "H"))
                            {
                                    // generate new coordinates
                                    computerguess[0] = r.Next(1, 9);
                                    computerguess[1] = r.Next(1, 9);
                            }


                            // the computer is guessing animation
                            //ComputerIsGuessing();

                            // unfortunately big if statement again to check if computer guess lines up with player's coordinates and if it does then edit the PRIMARY GRID
                            if ((computerguess[0] == intcoords1[0] && computerguess[1] == intcoords1[1]) || (computerguess[0] == intcoords2[0] && computerguess[1] == intcoords2[1]) || (computerguess[0] == intcoords3[0] && computerguess[1] == intcoords3[1]) || (computerguess[0] == intcoords4[0] && computerguess[1] == intcoords4[1]) || (computerguess[0] == intcoords5[0] && computerguess[1] == intcoords5[1]))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" One of your ships were struck!\n");
                                computerguesses += 1;
                                Thread.Sleep(1000);
                                // re print primary grid with a H on the place hit
                                primarygrid[computerguess[1] - 1, computerguess[0] - 1] = "H";
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{primarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{secondarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }
                                
                            }
                            else
                            {
                                // the computer is guessing again
                                //ComputerIsGuessing();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" The computer misses!\n");
                                Thread.Sleep(500);

                                // re print grid with a M on the place hit
                                primarygrid[computerguess[1] - 1, computerguess[0] - 1] = "M";
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{primarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(" 1 2 3 4 5 6 7 8");
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(i + 1);
                                    for (int j = 0; j < 8; j++)
                                    {
                                        // loop through and print all elements of 2d array
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write($"{secondarygrid[i, j]} ");
                                    }
                                    // new line between each row
                                    ResetColors();
                                    Console.WriteLine("");
                                }
                            }


                            if (userguesses == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nYou found all the computer's ships and won!");
                                Thread.Sleep(1000);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nGame over!");
                                Thread.Sleep(500);
                                gamedone = true;
                            }

                            if (computerguesses == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nThe computer hit all your ships and won!");
                                Thread.Sleep(1000);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nGame over!\n");
                                Thread.Sleep(500);
                                gamedone = true;
                            }
                        } while (!gamedone);


                        break;
                    case "2":
                        Console.WriteLine("in progress");
                        break;

                    case "3":
                        Console.WriteLine("in progress");
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\nG");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("d");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("b");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("y");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("e");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                        
                    default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Error: Invalid input string");
                        break;
                }



                static void LoadingAnimation()
                {
                    // weird unnecessary loading animation
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nStarting new game");
                    Console.SetCursorPosition(17, Console.CursorTop - 1);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.SetCursorPosition(18, Console.CursorTop - 1);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.SetCursorPosition(19, Console.CursorTop - 1);
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(21, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Done!");
                    Thread.Sleep(1500);
                }


                static void CreateBaseGrid()
                {
                    // nested for-loop matrix for base grid 
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" 1 2 3 4 5 6 7 8");
                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(i + 1);
                        for (int j = 0; j < 8; j++)
                        {
                            // make it look pretty
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(". ");
                        }
                        // new line between each row
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                    }
                }

                static void ResetColors()
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                static void ComputerIsGuessing()
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string[] guessidentifiers = {"The computer prepares for battle", "The computer is adjusting its tactics", "The computer is scanning the battlefield", "The computer is broadcasting a message to you: 010001000100100101000101", "The computer is making a calculated guess", "A fan is whirring somewhere", "The computer begins overclocking itself for extra efficiency", "The computer is undergoing a situational analysis", "The computer begins measuring change in potential energy", "The computer is thinking", "The AI is racking its cache", "The computer prepares for its turn", "The computer begins trash talking you in machine code", "The computer is analysing its choices"};
                    Random r = new Random();
                    string sentenceinuse = guessidentifiers[r.Next(0, guessidentifiers.Length)];

                    Console.WriteLine("\n" + sentenceinuse);

                    Console.SetCursorPosition(sentenceinuse.Length, Console.CursorTop - 1);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.SetCursorPosition(sentenceinuse.Length + 1, Console.CursorTop - 1);
                    Console.WriteLine(".");
                    Thread.Sleep(500);
                    Console.SetCursorPosition(sentenceinuse.Length + 2, Console.CursorTop - 1);
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(sentenceinuse.Length + 3, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                /*static int RandomNumberExcluding(int values)
                {
                    var exclude = new HashSet<int>() { 5, 7, 1};
                    var range = Enumerable.Range(1, 8).Where(i => !exclude.Contains(i));

                    var rand = new System.Random();
                    int index = rand.Next(0, 8 - exclude.Count);
                    return range.ElementAt(index);
                }*/
            }
        }
    }
}