using System;
using System.Net.Sockets;
using System.Text;

namespace TicTacToeNetwork
{
    public class HostGame
    {
        static int centerY = Console.WindowHeight / 2 - 1;
        static int centerX = Console.WindowWidth / 2 - 1;
        static int menuX = centerX - 4;
        static int menuY = centerY + 1;

        public void StartHost(int port)
        {
            TcpListener server = new TcpListener(port);
            TcpClient client = new TcpClient();
            try
            {
              

                server.Start();
                int i1 = 0;
                client = server.AcceptTcpClient();
                NetworkStream str = client.GetStream();
                if (client.Connected && i1 == 0)
                {
                    Display.WriteCyan(centerX - 20, centerY - 5, "Welcome to TicTacToe Network Version!");
                    i1++;
                    Console.Clear(); Game.Table();

                }
                while (true)
                {
                    if (JoinGame.CheckIfWin("X") == true)
                    {
                        Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                        Display.WriteYellow(menuX, menuY + 6, "Back");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + JoinGame.Winner);
                        while (true)
                        {
                            Program.ClearKeyBuffer();

                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        ");
                                server.Stop();
                                client.Close();
                                Console.Clear();
                                return;
                            }
                        }

                    }
                    if (JoinGame.CheckIfWin("O") == true)
                    {
                        Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                        Display.WriteYellow(menuX, menuY + 6, "Back");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + JoinGame.Winner);
                        while (true)
                        {
                            Program.ClearKeyBuffer();

                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        " );
                                server.Stop();
                                client.Close();
                                Console.Clear();
                                return;
                            }
                        }

                    }

                    string text = "";
                    byte[] receiveBuffer = new byte[999];
                    byte[] sendData = new byte[999];

                    Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        ");
                    Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "Other player turn: ");

                    string msg;

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

                    for (int i = 0; i < receiveBuffer.Length; i++)
                    {
                        receiveBuffer[i] = 0;
                    }

                    if (JoinGame.CheckIfWin("X") == true)
                    {
                        Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                        Display.WriteYellow(menuX, menuY + 6, "Back");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + JoinGame.Winner);
                        while (true)
                        {
                            Program.ClearKeyBuffer();

                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        ");
                                server.Stop();
                                client.Close();
                                Console.Clear();
                                return;
                            }
                        }

                    }
                    if (JoinGame.CheckIfWin("O") == true)
                    {
                        Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                        Display.WriteYellow(menuX, menuY + 6, "Back");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "                        ");
                        Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3, "Winner: " + JoinGame.Winner);
                        Display.WriteYellow(menuX - 10, menuY + 5, "                                                 ");
                        while (true)
                        {
                            Program.ClearKeyBuffer();

                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        ");
                                server.Stop();
                                client.Close();
                                Console.Clear();
                                return;
                            }
                        }

                    }

                    Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "                        ");
                    Display.WriteRed(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4, "Your turn:");
                    Game.Start();
                    sendData = Encoding.ASCII.GetBytes(JoinGame.txtME);
                    Game.Table();
                    str.Write(sendData, 0, sendData.Length);

                    Game.ex = true;
                }
            }

            catch(SocketException e)
            {
                Console.Clear();
                Display.WriteCyan(centerX - 20, centerY - 5, "           Server already exist...");
                Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                Display.WriteYellow(menuX, menuY + 6, "Back");
                while (true)
                {
                    Program.ClearKeyBuffer();
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break; ;
                    }
                }
            }

            catch(Exception e)
            {
                Console.Clear();
                Display.WriteCyan(centerX - 20, centerY - 5, "           No player avaible...");
                Display.WriteYellow(menuX - 10, menuY + 6, "                                                          ");
                Display.WriteYellow(menuX, menuY + 6, "Back");
                while (true)
                {
                    Program.ClearKeyBuffer();
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break; ;
                    }
                }
                server.Stop();
                client.Close();
            }
        }
    }
}
