using static System.Console;

namespace ConsoleMazeRunner
{
    public class Target
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string TargetMarker;
        public ConsoleColor TargetColor;

        public Target(int initialX, int initialY)
        {
            X = initialX-1;
            Y = initialY-1;
            TargetMarker ="X";
            TargetColor = ConsoleColor.Green;
        }
        public void Draw()
        {
            ForegroundColor = TargetColor;
            SetCursorPosition(X, Y + 2);
            Write(TargetMarker);
            ResetColor();
        }
    }
}
