﻿using System.ComponentModel;
using System.Diagnostics;

namespace KKA_Task_05
{
    internal class Labirint
    {
        public int X = 0;
        public int Y = 0;

        public int startPositionX = 0;
        public int startPositionY = 0;

        public int endPositionX = 0;
        public int endPositionY = 0;

        public string labirintSolution;

        public int[,] labirintCooridnatsSolution;
        public char[,] map;

        public void MainMenu()
        {
            int choice = 1;
            
            while (choice != 0)
            {
                Console.Write("Main menu.\n" +
                    "0. Exit.\n" +
                    "1. Start game.\n-> ");
                
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        StartGame();
                        break;
                }
            }
        }

        public void StartGame()
        {
            Console.Clear();
            LoadMap("1");
            SetProgressBar();
            SetWindow(100, 50);

            Console.SetCursorPosition(startPositionX, startPositionY);
            bool flag = true;
            bool win = true;
            while (flag)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.F1)
                {
                    ShowRightWay();
                    flag = false;
                    win = false;
                }
                else
                    Step(key);

                if ((X == endPositionX) && (Y == endPositionY))
                    flag = false;
            }

            Console.SetCursorPosition(0, endPositionY + 7);
            ProgressBar.WriteProgressBar(100, true);

            Console.SetCursorPosition(0, 40);
            if (win)
                Console.WriteLine("You win! Press any key to continue.");
            else Console.WriteLine("You took a hint and that's why we can't give you a win:///\n" +
                "Press any key to continue.");
            Console.ReadLine();

            Console.Clear();
        }

        public void Step(ConsoleKeyInfo key)
        {
            int tx = 0, ty = 0;
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    tx = -1;
                    ty = 0;
                    break;
                case ConsoleKey.RightArrow:
                    tx = 1;
                    ty = 0;
                    break;
                case ConsoleKey.UpArrow:
                    tx = 0;
                    ty = -1;
                    break;
                case ConsoleKey.DownArrow:
                    tx = 0;
                    ty = 1;
                    break;
            }

            if (CheckPosition(X + tx, Y + ty))
            {
                DrawPosition(tx, ty);
            }
        }

        public bool CheckPosition(int x, int y)
        {
            if (y < 0 || y > map.GetLength(0) ||
                x < 0 || x > map.GetLength(1))
            {
                return false;
            }
            if (map[y, x] == ' ')
            {
                return true;
            }
            return false;
        }

        public void DrawPosition(int nx, int ny)
        {
            
            ProgressBar.WriteProgressBar(Convert.ToInt16(GetProcent() / labirintCooridnatsSolution.GetLength(0) * 100), true);


            Console.SetCursorPosition(X, Y);
            Console.Write(" ");

            Console.SetCursorPosition(X + nx, Y + ny);
            Console.Write("^");

            X += nx;
            Y += ny;

            Console.SetCursorPosition(X, Y);
        }

        public void SetWindow(int w, int h)
        {
            Console.SetWindowSize(w, h);
            Console.SetCursorPosition(0, endPositionY + 5);
            Console.WriteLine("Labyrinth.\nF1 - show correct path.");
        }

        public void ShowRightWay()
        {
            X = startPositionX;
            Y = startPositionY;
            RightWayKey();
        }

        public void RightWayKey(bool load = false)
        {
            int tx = 0, ty = 0;
            int i = 0;
            foreach (char c in labirintSolution)
            {
                switch (c)
                {
                    case 'a':
                        tx = -1;
                        ty = 0;
                        break;
                    case 'd':
                        tx = 1;
                        ty = 0;
                        break;
                    case 'w':
                        tx = 0;
                        ty = -1;
                        break;
                    case 's':
                        tx = 0;
                        ty = 1;
                        break;
                }
                if (load)
                {
                    AddRightPosition(tx, ty, i++);
                } else
                    DrawRightWay(tx, ty);
            }
        }

        public void AddRightPosition(int tx, int ty, int i)
        {
            labirintCooridnatsSolution[i, 0] = X;
            labirintCooridnatsSolution[i, 1] = Y;
            X += tx;
            Y += ty;
        }

        public void DrawRightWay(int nx, int ny)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(X, Y);
            Console.Write("█");

            Console.SetCursorPosition(X + nx, Y + ny);
            Console.Write("^");

            X += nx;
            Y += ny;

            Console.SetCursorPosition(X, Y);
        }

        public void LoadMap(string mapName)
        {
            string[] mapArray = File.ReadAllLines("maps/" + mapName + ".map");
            char[,] mapCharArray = new char[mapArray.Length, mapArray[0].Length];

            for (int i = 0; i < mapCharArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapCharArray.GetLength(1); j++)
                {
                    mapCharArray[i, j] = mapArray[i][j];
                }
            }

            map = mapCharArray;

            string[] solutionArray = File.ReadAllLines("maps/" + mapName + ".map.sol");

            string[] startPositions = solutionArray[0].Split(':');
            startPositionX = Convert.ToInt16(startPositions[0]);
            startPositionY = Convert.ToInt16(startPositions[1]);

            string[] endPositions = solutionArray[1].Split(":");
            endPositionX = Convert.ToInt16(endPositions[0]);
            endPositionY = Convert.ToInt16(endPositions[1]);

            labirintSolution = solutionArray[2];

            X = startPositionX;
            Y = startPositionY;

            labirintCooridnatsSolution = new int[labirintSolution.Length, 2];
            RightWayKey(true);

            X = startPositionX;
            Y = startPositionY;

            PrintMap();

            
        }

        public void PrintMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public double GetProcent()
        {
            int procent = 1;

            for (int i = 0; i < labirintCooridnatsSolution.GetLength(0); i++)
            {
                if (labirintCooridnatsSolution[i, 0] == X &&
                labirintCooridnatsSolution[i, 1] == Y)
                {
                    procent = i;
                    break;
                }
            }

            if (procent == 0) { return 1; }
            return procent;
        }

        public void SetProgressBar()
        {
            ProgressBar.x = 0;
            ProgressBar.y = endPositionY + 7;
        }
    }
}
