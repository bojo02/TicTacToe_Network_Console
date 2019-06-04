using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TicTacToeNetwork
{
    public class Program
    {
        static ConsoleColor color = ConsoleColor.Black;

        static int centerY = Console.WindowHeight / 2 - 1;
        static int centerX = Console.WindowWidth / 2 - 1;

        static int menuX = centerX - 4;
        static int menuY = centerY + 1;

        public static int Port;
        public static string IP;

        public static StartMenuSelection Chosen = StartMenuSelection.Exit;
        public static SecondMenuSelection Chosen2 = SecondMenuSelection.Back;

        public static void Main(string[] args)
        {
            /////////////////main start
            ///

            Console.WindowHeight = 30;
            Console.WindowWidth = 120;

             Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            

            Console.Title = "TicTacToe \"Network edition\" 2.0";

            Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

            Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");
      
            //Show menu
            SelectMenu();



            Console.ReadKey();
            //////////////Main end
        }
        public static void SelectMenu()
        {
            int index = 0;

            Display.WriteYellow(menuX , menuY, "Start");

            Display.WriteWhite(menuX , menuY + 2, "Exit");

            while (true)
            {
                ClearKeyBuffer();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 == 0)
                    {
                        index--;
                        Console.BackgroundColor = color;
                        Display.WriteYellow(menuX , menuY, "Start");
                        Display.WriteWhite(menuX , menuY + 2, "Exit");
                        Console.BackgroundColor = color;
                    }
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 == 1)
                    {
                        index++;
                        Console.BackgroundColor = color;
                        Display.WriteWhite(menuX , menuY, "Start");
                        Display.WriteYellow(menuX , menuY + 2, "Exit");
                        Console.BackgroundColor = color;
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (index == 1)
                    {
                        Chosen = StartMenuSelection.Exit;
                    }
                    if (index == 0)
                    {
                        Chosen = StartMenuSelection.Start;
                    }
                    if (Chosen == StartMenuSelection.Exit)
                    {
                        Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");
                        Display.WriteCyan(centerX - 10, centerY - 5, "Thanks for playing!");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        SelectMenuHostOrClient();
                    }
                }
            }
        }

        public static void SelectMenuHostOrClient()
        {
            Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

            Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");


            int index = 0;

            Display.WriteYellow(menuX , menuY, "Join");

            Display.WriteWhite(menuX, menuY + 2, "Host");

            Display.WriteWhite(menuX, menuY + 4, "Back");

            while (true)
            {
                ClearKeyBuffer();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 == 0)
                    {
                        index--;
                        Console.BackgroundColor = color;
                        Display.WriteYellow(menuX , menuY, "Join");

                        Display.WriteWhite(menuX, menuY + 2, "Host");

                        Display.WriteWhite(menuX, menuY + 4, "Back");
                        Console.BackgroundColor = color;
                    }
                    else if (index - 1 == 1)
                    {
                        index--;
                        Console.BackgroundColor = color;
                        Display.WriteWhite(menuX , menuY, "Join");

                        Display.WriteYellow(menuX, menuY + 2, "Host");

                        Display.WriteWhite(menuX, menuY + 4, "Back");
                        Console.BackgroundColor = color;
                    }
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 == 2)
                    {
                        index++;
                        Console.BackgroundColor = color;
                        Display.WriteWhite(menuX , menuY, "Join");

                        Display.WriteWhite(menuX, menuY + 2, "Host");

                        Display.WriteYellow(menuX, menuY + 4, "Back");
                        Console.BackgroundColor = color;
                    }
                    else if (index + 1 == 1)
                    {
                        index++;
                        Console.BackgroundColor = color;
                        Display.WriteWhite(menuX, menuY, "Join");

                        Display.WriteYellow(menuX, menuY + 2, "Host");

                        Display.WriteWhite(menuX, menuY + 4, "Back");
                        Console.BackgroundColor = color;
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {

                    if (index == 1)
                    {
                        if (index == 1)
                        {
                            HostMenu();
                            Console.BackgroundColor = color;
                            Display.WriteWhite(menuX, menuY, "Join");

                            Display.WriteYellow(menuX, menuY + 2, "Host");

                            Display.WriteWhite(menuX, menuY + 4, "Back");
                            Console.BackgroundColor = color;
                        }
                    }
                    if (index == 0)
                    {
                        Console.Clear();
                        Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");
                        Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");
                        Chosen2 = SecondMenuSelection.Join;
                        Console.BackgroundColor = color;
                        SelectMenuJoin();
                    }
                    if (index == 2)
                    {
                        Console.Clear();
                        Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

                        Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");
                        Chosen2 = SecondMenuSelection.Back;
                        Console.BackgroundColor = color;
                        Display.WriteYellow(menuX , menuY, "Start");
                        Display.WriteWhite(menuX , menuY + 2, "Exit");
                        break;
                    }
                   
                }
            }
        }

        public static void SelectMenuJoin()
        {
            Console.Clear(); Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

            Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");

            Display.WriteYellow(menuX - 5, menuY, "IP Address: " + IP);
            Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
            Display.WriteWhite(menuX - 5, menuY + 4, "Start");
            Display.WriteWhite(menuX - 5, menuY + 8, "Back");

            int index = 0;

            while (true)
            {
                ClearKeyBuffer();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 == 0)
                    {
                        index--;
                        Display.WriteYellow(menuX - 5, menuY, "IP Address: " + IP);
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteWhite(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");
                    }
                    else if (index - 1 == 1)
                    {
                        index--;
                        Display.WriteWhite(menuX - 5, menuY, "IP Address: " + IP);
                        Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteWhite(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");
                    }
                    else if (index - 1 == 2)
                    {
                        index--;
                        Display.WriteWhite(menuX - 5, menuY, "IP Address: " + IP);
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteYellow(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");
                    }
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 == 3)
                    {
                        index++;
                        Display.WriteWhite(menuX - 5, menuY, "IP Address: " + IP);
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteWhite(menuX - 5, menuY + 4, "Start");
                        Display.WriteYellow(menuX - 5, menuY + 8, "Back");
                    }
                    else if (index + 1 == 1)
                    {
                        index++;

                        Display.WriteWhite(menuX - 5, menuY, "IP Address: " + IP);
                        Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteWhite(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");
                    }
                    else if (index + 1 == 2)
                    {
                        index++;
                        Display.WriteWhite(menuX - 5, menuY, "IP Address: " + IP);
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteYellow(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {

                    if (index == 1)
                    {
                        Port = 0;
                        Display.WriteYellow(menuX - 5, menuY + 2, "Port number:                     " );
                        Console.SetCursorPosition(menuX + 8, menuY + 2);
                        try
                        {
                            Port = int.Parse(Console.ReadLine());
                            Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + Port);
                        }
                        catch(Exception e)
                        {
                            Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + "0                   " );
                        }
                       
                    }
                    if(index == 2)
                    {
                        JoinGame jg = new JoinGame();
                        jg.Network(IP, Port);

                          Game.first = " ";
                        Game.second = " ";
                        Game.third = " ";
                        Game.fourth = " ";
                        Game.fifth = " ";
                        Game.sixth = " ";
                        Game.seventh = " ";
                        Game.eight = " ";
                        Game.nineth = " ";

        Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

                        JoinGame.exit = false;
                        JoinGame.txtME = " ";
        JoinGame.Winner = "";

        Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");

                        Display.WriteWhite(menuX - 5, menuY, "IP Address: " + IP);
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteYellow(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");
                        JoinGame.exit = false;
                    }
                    if (index == 0)
                    {
                       
                        Display.WriteWhite(menuX - 5, menuY, "IP Address:                      ");
                        Console.SetCursorPosition(menuX + 7, menuY);
                        IP = Console.ReadLine();
                        Display.WriteYellow(menuX - 5, menuY, "IP Address: " + IP);
                    }
                    if (index == 3)
                    {
                        Console.Clear();

                        Display.WriteYellow(menuX, menuY + 1, "Join");

                        Display.WriteWhite(menuX, menuY + 3, "Host");

                        Display.WriteWhite(menuX, menuY + 5, "Back");


                        Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");
                        Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");

                        break;
                    }
                }
                
            }
        }

        public static void HostMenu()
        {
            Console.Clear(); Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

            Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");

            Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + Port);
            Display.WriteWhite(menuX - 5, menuY + 4, "Start");
            Display.WriteWhite(menuX - 5, menuY + 8, "Back");

            int index = 0;

            while (true)
            {
                ClearKeyBuffer();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 == 0)
                    {
                        index--;
                        Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteWhite(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");

                    }
                    if (index - 1 == 1)
                    {
                        index--;
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteYellow(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");

                    }
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 == 2)
                    {
                        index++;
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteWhite(menuX - 5, menuY + 4, "Start");
                        Display.WriteYellow(menuX - 5, menuY + 8, "Back");

                    }
                    if (index + 1 == 1)
                    {
                        index++;
                        Display.WriteWhite(menuX - 5, menuY + 2, "Port number: " + Port);
                        Display.WriteYellow(menuX - 5, menuY + 4, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 8, "Back");

                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (index == 1)
                    {
                        Console.Clear();
                        Display.WriteCyan(centerX - 20, centerY - 5, "     Waiting for player to join!");

                        Display.WriteCyan(centerX - 20, centerY - 2, "       Port: " + Port);
                        string _ip = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
                        Display.WriteCyan(centerX - 20, centerY - 3, "       IPv4: " + _ip);

                        HostGame hg = new HostGame();
                        hg.StartHost(Port);
                        JoinGame.exit = false;
                        JoinGame.Winner = "";
                        Display.WriteWhite(menuX - 5, menuY + 3, "Port number: " + Port);
                        Display.WriteYellow(menuX - 5, menuY + 5, "Start");
                        Display.WriteWhite(menuX - 5, menuY + 9, "Back");
                        Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

                        Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");
                        Game.first = " ";
                        Game.second = " ";
                        Game.third = " ";
                        Game.fourth = " ";
                        Game.fifth = " ";
                        Game.sixth = " ";
                        Game.seventh = " ";
                        Game.eight = " ";
                        Game.nineth = " ";

                    }
                    if (index == 2)
                    {
                        Console.Clear();
                        Console.Clear(); Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");

                        Display.WriteGreen(Console.WindowWidth - 17, Console.WindowHeight - 1, "By Danger_boy21");

                        return;
                    }
                    if (index == 0)
                    {
                        Port = 0;
                        Display.WriteYellow(menuX - 5, menuY + 2, "Port number:                     ");
                        Console.SetCursorPosition(menuX + 8, menuY + 2);
                        try
                        {
                            Port = int.Parse(Console.ReadLine());
                            Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + Port);
                        }
                        catch (Exception e)
                        {
                            Display.WriteYellow(menuX - 5, menuY + 2, "Port number: " + "0                   ");
                        }

                    }
                }
            }
        }

        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }
    }
}
