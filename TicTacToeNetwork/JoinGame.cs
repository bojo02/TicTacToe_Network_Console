using System;
using System.Net.Sockets;
using System.Text;

namespace TicTacToeNetwork
{
    public class JoinGame
    {
        public static string txtME = " ";

        public static string IP = Program.IP;
        public static int Port = Program.Port;

        static int centerY = Console.WindowHeight / 2 - 1;
        static int centerX = Console.WindowWidth / 2 - 1;
        static int menuX = centerX - 4;
        static int menuY = centerY + 1;
        public static bool exit = false;
        public static string Winner = "";

        public static bool CheckIfWin(string txt)
        {
            if (Game.first != " " && Game.second != " " && Game.third != " " && Game.fourth != " " && Game.fifth != " " && Game.sixth != " " &&
                Game.seventh != " " && Game.eight != " " && Game.nineth != " ")
            {
                Winner = "No winner...";
                return true;
            }

            else if (Game.first == txt && Game.second == txt && Game.third == txt)
            {
                Winner = Game.first;
                return true;
            }
            else if (Game.fourth == txt && Game.fifth == txt && Game.sixth == txt)
            {
                Winner = Game.fifth;
                return true;
            }
            else if (Game.seventh == txt && Game.eight == txt && Game.nineth == txt)
            {
                Winner = Game.seventh;
                return true;
            }


            else if (Game.first == txt && Game.fourth == txt && Game.seventh == txt)
            {
                Winner = Game.seventh;
                return true;
            }
            else if (Game.second == txt && Game.fifth == txt && Game.eight == txt)
            {
                Winner = Game.fifth;
                return true;
            }
            else if (Game.third == txt && Game.sixth == txt && Game.nineth == txt)
            {
                Winner = Game.nineth;
                return true;
            }



            else if (Game.first == txt && Game.fifth == txt && Game.nineth == txt)
            {
                Winner = Game.nineth;
                return true;
            }
            else if (Game.third == txt && Game.fifth == txt && Game.seventh == txt)
            {
                Winner = Game.nineth;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Network(string ip, int port)
        {

            Console.Clear();

            try
            {
                TcpClient client = new TcpClient(ip, port);
                NetworkStream str = client.GetStream();
                byte[] receiveBuffer = new byte[999];
                Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 6, "Enter cords: ");
                while (!exit)
                {
                    try
                    {
                        if (CheckIfWin("X") == true)
                        {
                            Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                            Display.WriteYellow(menuX, menuY + 6, "Back");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + Winner);
                            while (true)
                            {
                                Program.ClearKeyBuffer();

                                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                                if (keyInfo.Key == ConsoleKey.Enter)
                                {
                                    Display.WriteYellow(menuX - 10, menuY + 7, "                                                          ");
                                    client.Close();
                                    Console.Clear();
                                    return;
                                }
                            }

                        }
                        if (CheckIfWin("O") == true)
                        {
                            Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                            Display.WriteYellow(menuX, menuY + 6, "Back");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + Winner);
                            while (true)
                            {
                                Program.ClearKeyBuffer();

                                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                                if (keyInfo.Key == ConsoleKey.Enter)
                                {
                                    Display.WriteYellow(menuX - 10, menuY + 7, "                                                          ");
                                    client.Close();
                                    Console.Clear();
                                    return;
                                }
                            }

                        }
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        ");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "Your turn:");
                        Game.Start();
                        Game.Table();

                        byte[] sendData = new byte[999];

                        sendData = Encoding.ASCII.GetBytes(txtME);



                        str.Write(sendData, 0, sendData.Length);


                        string msg = "";


                        bool exit = false;
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        ");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "Other player turn: ");
                        if (CheckIfWin("X") == true)
                        {
                            Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                            Display.WriteYellow(menuX, menuY + 6, "Back");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + Winner);
                            while (true)
                            {
                                Program.ClearKeyBuffer();

                                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                                if (keyInfo.Key == ConsoleKey.Enter)
                                {
                                    Display.WriteYellow(menuX - 10, menuY + 7, "                                                          ");
                                    client.Close();
                                    Console.Clear();
                                    return;
                                }
                            }

                        }
                        if (CheckIfWin("O") == true)
                        {
                            Display.WriteYellow(menuX - 10, menuY + 7, "                                                          ");
                            Display.WriteYellow(menuX, menuY + 6, "Back");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                            Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + Winner);
                            while (true)
                            {
                                client.Close();
                                Program.ClearKeyBuffer();

                                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                                if (keyInfo.Key == ConsoleKey.Enter)
                                {
                                    Display.WriteYellow(menuX - 10, menuY + 7, "                                                          ");
                                    Console.Clear();
                                    return;
                                }
                            }

                        }
                        while (!exit)
                        {
                            str.Read(receiveBuffer, 0, receiveBuffer.Length);
                            msg = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length);

                            if (msg.Contains("1 1")) Game.first = "O";
                            if (msg.Contains("1 2")) Game.second = "O";
                            if (msg.Contains("1 3")) Game.third = "O";
                            if (msg.Contains("2 1")) Game.fourth = "O";
                            if (msg.Contains("2 2")) Game.fifth = "O";
                            if (msg.Contains("2 3")) Game.sixth = "O";
                            if (msg.Contains("3 1")) Game.seventh = "O";
                            if (msg.Contains("3 2")) Game.eight = "O";
                            if (msg.Contains("3 3")) Game.nineth = "O";

                            Game.Table();
                            exit = true;
                            Game.ex = true;


                        }




                    }
                    catch (Exception e)
                    {
                        client.Close();
                        str.Close();
                        Console.Clear(); Display.WriteCyan(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 5, "The player exit...");
                        Display.WriteYellow(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 8, "Back");
                        while (true)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                exit = true;

                                Console.Clear();

                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Clear(); Display.WriteCyan(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 5, "Server not found...");
                Display.WriteYellow(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 8, "Back");
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        exit = true;

                        Console.Clear();

                        break;
                    }
                }
            }
        }
    }
}

