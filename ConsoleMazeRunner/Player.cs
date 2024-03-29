﻿using static System.Console;

namespace ConsoleMazeRunner
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "O";
            PlayerColor = ConsoleColor.Red;
        }
        public void Draw ()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition (X, Y+2);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}
