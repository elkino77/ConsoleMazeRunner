using static System.Console;

namespace ConsoleMazeRunner
{
    public class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        //private Target CurrentTarget;

        public void Start(int size)
        {
            //string[,] Grid = new string[size,size];

            //for (int i = 0; i < Grid.GetLength(0); i++)
            //{
            //    for (int j = 0; j < Grid.GetLength(1); j++)
            //    {
            //        if (j==0 || i==size-1)
            //        {
            //            Grid[i, j] = " ";
            //        }
            //        else
            //        {
            //            Grid[i, j] = "=";
            //        }
            //    }
            //}
            string[,] Grid = {
                {"=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","=","="},
                {" "," ","=","=","=","=","=","=","=","=","=","=","=","=","="," ","=","=","=","=","=","=","=","X","="},
                {"="," ","=","=","=","=","=","=","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," "," "},
                {"="," "," ","=","=","=","=","=","=","=","=","=","=","=","="," ","=","=","=","=","=","="," "," "," "},
                {"=","="," "," ","=","=","=","=","="," "," "," "," "," "," "," ","=","=","=","=","=","="," ","="," "},
                {"=","=","="," "," ","=","=","="," "," ","=","=","=","=","=","=","=","=","=","=","=","="," ","="," "},
                {"=","=","=","="," ","=","=","="," ","=","=","=","=","=","=","=","=","=","=","=","=","="," ","="," "},
                {"=","=","=","="," ","=","=","="," ","=","=","=","=","=","=","=","=","=","=","=","=","="," ","="," "},
                {"=","=","=","="," "," "," "," "," ","=","=","=","=","=","="," "," "," "," "," "," "," "," "," "," "},
                {"=","=","=","="," ","=","="," ","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," "," "},
                {"=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," "," "},
                {"=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," "," "},
                {"=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," "," "},
                {"=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," ","="},
                {"=","=","=","=","=","=","="," "," "," "," "," "," "," "," "," ","=","=","=","=","=","=","="," ","="},
                {"=","=","=","=","=","=","=","=","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," ","="},
                {"=","=","=","=","=","=","=","=","=","=","=","=","=","=","="," ","=","=","=","=","=","=","="," ","="},
                {"=","=","=","=","=","=","=","=","=","=","=","=","=","=","="," ","=","=","=","=","=","=","=","=","="},

            };

            MyWorld = new World(Grid); 
            CurrentPlayer = new Player(0, 0);
            //CurrentTarget = new Target(size, size);
            RunGameLoop();
        }
        private void DisplayOutro()
        {
            Clear();
            WriteLine("Juego terminado con éxito");
            WriteLine("Gracias por Jugar con Nosotros");
            ReadKey(true);
        }
        private void DisplayIntro()
        {
            WriteLine("Bienvenidos a jugar MAZE");
            WriteLine("Instruciones");
            WriteLine("Use las feclas del teclado para moverse");
            WriteLine("El objetivo es llegar hasta la X");
            WriteLine("Presione Enter para iniciar");
            ReadKey(true);
        }
        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
            //CurrentTarget.Draw();
        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key) 
            {
                case ConsoleKey.UpArrow:
                    if(MyWorld.IsValid(CurrentPlayer.X,CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsValid(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsValid(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsValid(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default: break;
            }
        }

        private void RunGameLoop()
        {
            DisplayIntro();
            while (true) 
            {
                //Draw everything
                DrawFrame();
                //Check for player input fron the keyboard and move the player
                HandlePlayerInput();
                //Check if the player has reached the exit ana end the game if so
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X,CurrentPlayer.Y);
                if (elementAtPlayerPos == "X") 
                {
                    break;
                }
                //Give the Console an chance to render
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}
