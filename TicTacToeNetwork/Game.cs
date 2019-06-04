using System;

namespace TicTacToeNetwork
{
    public class Game
    {
        public static bool ex = true;
        public static bool exOff = true;
        public static bool exitStart = true;
        public static bool exitStart2 = true;

        public static string first = " ";
        public static string second = " ";
        public static string third = " ";
        public static string fourth = " ";
        public static string fifth = " ";
        public static string sixth = " ";
        public static string seventh = " ";
        public static string eight = " ";
        public static string nineth = " ";

        public static void Table()
        {
            string up = ("      1       2       3");
            string one = ("  |       |       |       |");
            string two = ("1 |   " + first + "   |   " + second + "   |   "+third+"   |");
            string three = ("  |       |       |       |");
            string four = ("  |-------|-------|-------|");
            string five = ("  |       |       |       |");
            string six = ("2 |   " + fourth + "   |   " + fifth + "   |   " + sixth + "   |");
            string seven = ("  |       |       |       |");
            string eigh = ("  |-------|-------|-------|");
            string nine = ("  |       |       |       |");
            string ten = ("3 |   " + seventh + "   |   " + eight + "   |   " + nineth + "   |");
            string eleven = ("  |       |       |       |");
            string zero = ("   -----------------------");

            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 11, up);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 10, zero);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 9, one);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 8, two);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 7, three);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 6, four);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 5, five);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 4, six);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 3, seven);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 2, eigh);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 1, nine);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 0, ten);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 1, eleven);
            Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 2, zero);
        }

        public static void Start2()
        {

        }

       public static void Restart()
        {
            first = " ";
            second = " ";
            third = " ";
            fourth = " ";
            fifth = " ";
            sixth = " ";
            seventh = " ";
            eight = " ";
            nineth = " ";
        }

        public static void Start()
        {

                Table();
                string cords = "";
                Display.WriteCyan(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 6, "Enter cords: ");

                while (ex == true && exOff)
                {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                cords = Console.ReadLine();

                    if (cords == "1 1" && first == " ")
                    {
                        first = "X";
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false;
                    JoinGame.txtME = cords;
                    }
                    else if (cords == "1 2" && second == " ")
                    {
                        second = "X"; Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else if (cords == "1 3" && third == " ")
                    {
                        third = "X"; Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else if (cords == "2 1" && fourth == " ")
                    {
                        fourth = "X"; Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else if (cords == "2 2" && fifth == " ")
                    {
                        fifth = "X"; Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else if (cords == "2 3" && sixth == " ")
                    {
                        sixth = "X"; Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else if (cords == "3 1" && seventh == " ")
                    {
                        seventh = "X"; Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else if (cords == "3 2" && eight == " ")
                    {
                        eight = "X"; Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else if (cords == "3 3" && nineth == " ")
                    {
                        nineth = "X";
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                        ex = false; JoinGame.txtME = cords;
                }
                    else
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 6);
                        Console.WriteLine("                    ");
                    }
                
            }
        }
    }
}
