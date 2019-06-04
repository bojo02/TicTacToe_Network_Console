using System;

namespace TicTacToeNetwork
{
    public class Display
    {
        public static void WriteCyan(int x, int y, string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteYellow(int x, int y, string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteWhite(int x, int y, string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WriteGreen(int x, int y, string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WriteRed(int x, int y, string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ResetColor();
        }

    }
}
