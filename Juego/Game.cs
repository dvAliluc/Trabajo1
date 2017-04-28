using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Game
{
    class Game
    {

        
        private bool startgame = true;
        private int e = 1;
        private char p1 = 'O', p2 = 'Y', obs = '■', en = 'M';   

        private ConsoleKeyInfo userKey;

        private Random G = new Random();
        private Personaje player1 = new Personaje();
        private Personaje player2 = new Personaje();
        //private Bala[] bullet = new Bala[1];
        private Enemigos[] Enem = new Enemigos[10];
        private Obstaculo[] Obst = new Obstaculo[15];

        
        public void Iniciar()
        {
            WebRequest req = WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition.text%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22buenosaires%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            JObject data = JObject.Parse(sr.ReadToEnd());

            
            string weather = data.SelectToken("query.results.channel.item.condition.text").ToString();

            if (weather == "Sunny")
            { 
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Clima Actual: Soleado");
            }
            if (weather == "Cloudy")
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine("Clima Actual: Nublado");
            }
            if (weather == "Breezy")
            {   
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Clima Actual: Vientoso");
            }
            
            Console.SetBufferSize(121, 30);

            if (File.Exists("intro.txt") != true)
            {
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("BIENVENIDO, POR FAVOR ESCRIBIR TU ELECCIÓN Y APRETAR ENTER");
                FileStream fils = File.Create("intro.txt");
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
            Console.WriteLine("[1] EMPEZAR JUEGO    [2] MULTIPLAYER   [3] EXIT" );
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
                        Console.WriteLine(p1 + " = PLAYER      "+ obs + " = OBSTACULO    "+ en +" = ENEMIGO");
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

                                Enem[i].Movement();
                                Enem[i].Show();

                            }
                            player1.Show();
                            player1.DibujarVidas();
                            /*if (bullet[0] != null)
                            {
                                if(bullet[0].Movimiento())
                                {
                                    bullet[0] = null;
                                }
                            }*/
                            
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
                                   /* case ConsoleKey.Spacebar://Disparo de bala
                                        if(bullet[0] == null)
                                            bullet[0] = new Bala(player1.getPosX(),player1.getPosY(), player1.direccion);
                                        break;*/
                                }
                            }
                            for (int i = 0; i < Obst.Length; i++)
                            {
                                if (player1.getPosX() == Obst[i].getPosX() && player1.getPosY() == Obst[i].getPosY())
                                {
                                    if(player1.getVidas() > 1)
                                    {
                                        player1.Start(50, 20, p1);//reinicio posicion
                                        player1.setVidas(player1.getVidas()-1);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.SetCursorPosition(50, 12);
                                        Console.WriteLine("G A M E    O V E R");
                                        Console.ReadLine();
                                        startgame = false;
                                        player1.setVidas(3);
                                    }
                                }
                            }
                            for (int i = 0; i < Enem.Length; i++)
                            {
                                if (player1.getPosX() == Enem[i].getPosX() && player1.getPosY() == Enem[i].getPosY())
                                {
                                    if (player1.getVidas() > 1)
                                    {
                                        player1.Start(50, 20, p1);//reinicio posicion
                                        player1.setVidas(player1.getVidas() - 1);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.SetCursorPosition(50, 12);
                                        Console.WriteLine("G A M E    O V E R");
                                        Console.ReadLine();
                                        startgame = false;
                                        player1.setVidas(3);
                                    }
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

                                Enem[i].Movement();
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
                                    Console.SetCursorPosition(50, 12);
                                    Console.WriteLine("G A M E    O V E R");
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
                                    Console.SetCursorPosition(50, 12);
                                    Console.WriteLine("G A M E    O V E R");
                                    Console.ReadLine();
                                    startgame = false;

                                }

                            }
                            if (player1.getPosX() == player2.getPosX() && player1.getPosY() == player2.getPosY())
                            {
                                Console.Clear();
                                Console.SetCursorPosition(50, 12);
                                Console.WriteLine("G A M E    O V E R");
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