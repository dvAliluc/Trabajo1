using System;
using System.IO;
namespace Game
{
    class Game
    {

        

        
        private bool startgame = true;
        private int e = 1;
        private char p1 = 'X', p2 = 'Y', obs = '■', en = '<';   

        private ConsoleKeyInfo userKey;

        private Random G = new Random();
        private Personaje player1 = new Personaje();
        private Personaje player2 = new Personaje();
        private Enemigos[] Enem = new Enemigos[5];
        private Obstaculo[] Obst = new Obstaculo[20];

        
        public void Iniciar()
        {
            if (File.Exists("intro.lol") != true)
            {
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("BIENVENIDO, POR FAVOR ESCRIBIR TU ELECCIÓN Y APRETAR ENTER");
                FileStream fils = File.Create("intro.lol");
                StreamWriter sw = new StreamWriter(fils);
                sw.Close();
                fils.Close();
            }

            for (int i = 0; i<Enem.Length; i++)
                    Enem[i] = new Enemigos();
                    
    
            for (int i = 0; i<Enem.Length; i++)
                Enem[i].Start(G.Next(1, 120), G.Next(1, 30), en);
            

            for (int i = 0; i<Obst.Length; i++)
                Obst[i] = new Obstaculo();
            
            for (int i = 0; i<Obst.Length; i++)
                Obst[i].Start(G.Next(1, 120), G.Next(1, 30), obs);
           }
        public void Run()
        {
            while (e != 3 || startgame == true) {
                Console.SetCursorPosition(35, 12);
            Console.WriteLine("[1] EMPEZAR JUEGO    [2] MULTIPLAYER   [3] EXIT");
                Console.SetCursorPosition(60, 14);
                

                try
                {
                    e = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("INGRESAR NUMERO");
                    try
                    {
                        e = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ERROR");
                        System.Threading.Thread.Sleep(1000);
                        e = 3;
                        
                    }


                }
                System.Threading.Thread.Sleep(0);
                Console.Clear();
                
                switch (e)
                {
                    
                    case 1:
                        Console.SetCursorPosition(49, 10);
                        Console.WriteLine("MOVIMIENTO: FLECHAS");
                        Console.SetCursorPosition(35, 12);
                        Console.WriteLine(" X = PLAYER      ■ = OBSTACULO    < = ENEMIGO");
                        Console.SetCursorPosition(44, 14);
                        Console.WriteLine("APRETAR ENTER PARA CONTINUAR");
                        Console.ReadLine();
                        Console.Clear();
                        startgame = true;
                        player1.Start(50, 20, p1);
                        while (startgame)
                        {

                            for (int i = 0; i < Obst.Length; i++)
                            {
                                Obst[i].Show();
                            }
                            for (int i = 0; i < Enem.Length; i++)
                            {

                                Enem[i].MoveLeft();
                                Enem[i].Show();

                            }
                            player1.Show();

                            
                            if (Console.KeyAvailable)
                            {
                                userKey = Console.ReadKey(true);

                                switch (userKey.Key)
                                {


                                    case ConsoleKey.Backspace:
                                        Console.Clear();
                                        startgame = false;
                                        break;

                                    case ConsoleKey.UpArrow:
                                        player1.MoveUp();

                                        break;
                                    case ConsoleKey.DownArrow:

                                        player1.MoveDown();

                                        break;
                                    case ConsoleKey.RightArrow:
                                        player1.MoveRight();

                                        break;
                                    case ConsoleKey.LeftArrow:
                                        player1.MoveLeft();
                                        break;
                                }
                            }
                            for (int i = 0; i < Obst.Length; i++)
                            {
                                if (player1.getPosX() == Obst[i].getPosX() && player1.getPosY() == Obst[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    startgame = false;

                                }

                            }
                            for (int i = 0; i < Enem.Length; i++)
                            {
                                if (player1.getPosX() == Enem[i].getPosX() && player1.getPosY() == Enem[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    startgame = false;

                                }

                            }

                            System.Threading.Thread.Sleep(50);
                            Console.Clear();
                        }
                        break;
                    case 2:
                        Console.SetCursorPosition(49, 10);
                        Console.WriteLine("MOVIMIENTO: FLECHAS");
                        Console.SetCursorPosition(28, 12);
                        Console.WriteLine(" X = PLAYER 1    Y = PLAYER 2     ■ = OBSTACULO    < = ENEMIGO");
                        Console.SetCursorPosition(44, 14);
                        Console.WriteLine("APRETAR ENTER PARA CONTINUAR");
                        Console.ReadLine();
                        Console.Clear();
                        startgame = true;
                        player1.Start(50, 20, p1);
                        player2.Start(40, 20, p2);
                        while (startgame)
                        {

                            for (int i = 0; i < Obst.Length; i++)
                            {
                                Obst[i].Show();
                            }
                            for (int i = 0; i < Enem.Length; i++)
                            {

                                Enem[i].MoveLeft();
                                Enem[i].Show();

                            }
                            player1.Show();
                            player2.Show();

                            if (Console.KeyAvailable)
                            {
                                userKey = Console.ReadKey(true);

                                switch (userKey.Key)
                                {


                                    case ConsoleKey.Backspace:
                                        Console.Clear();
                                        startgame = false;
                                        break;

                                    case ConsoleKey.UpArrow:
                                        player1.MoveUp();

                                        break;
                                    case ConsoleKey.DownArrow:

                                        player1.MoveDown();

                                        break;
                                    case ConsoleKey.RightArrow:
                                        player1.MoveRight();

                                        break;
                                    case ConsoleKey.LeftArrow:
                                        player1.MoveLeft();
                                        break;
                                    case ConsoleKey.W:
                                        player2.MoveUp();

                                        break;
                                    case ConsoleKey.S:

                                        player2.MoveDown();

                                        break;
                                    case ConsoleKey.D:
                                        player2.MoveRight();

                                        break;
                                    case ConsoleKey.A:
                                        player2.MoveLeft();
                                        break;
                                }
                            }

                            for (int i = 0; i < Obst.Length; i++)
                            {
                                if (player1.getPosX() == Obst[i].getPosX() && player1.getPosY() == Obst[i].getPosY()
                                    || player2.getPosX() == Obst[i].getPosX() && player2.getPosY() == Obst[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    startgame = false;

                                }

                            }
                            for (int i = 0; i < Enem.Length; i++)
                            {
                                if (player1.getPosX() == Enem[i].getPosX() && player1.getPosY() == Enem[i].getPosY()
                                    || player2.getPosX() == Enem[i].getPosX() && player2.getPosY() == Enem[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    startgame = false;

                                }

                            }
                            if (player1.getPosX() == player2.getPosX() && player1.getPosY() == player2.getPosY())
                            {
                                Console.Clear();
                                Console.SetCursorPosition(50, 5);
                                Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                Console.ReadLine();
                                startgame = false;
                            }

                            System.Threading.Thread.Sleep(50);
                            Console.Clear();
                        }
                        break;
                    
                    case 3:
                        Console.Clear();
                        startgame = false;
                        break;
                        

                }
                
            
            }
        }
    }


     
}