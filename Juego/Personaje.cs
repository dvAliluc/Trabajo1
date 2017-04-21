using System;

namespace Game
{
    class Personaje
    {
        private int pX;
        private int pY;
        private char Char;
        private int vidas = 3;
        public  int direccion = 2;
        
        public void Start(int _x , int _y , char pj)
        {
            pX = _x;
            pY = _y;
            Char = pj;
        }
        public int getVidas()
        {
            return vidas;
        }
        public void setVidas(int _vidas)
        {
            vidas = _vidas;
        }
        public void Show()
        {
            Console.SetCursorPosition(pX, pY);
            Console.WriteLine(Char);
        }
        public void setChar(char ch)
        {
            Char = ch;
        }
        public int getPosX()
        {
            return pX;
        }
        public int getPosY()
        {

            return pY;
        }
        public void MoveUp()
        {
            if(pY!=0)
            {
                pY -= 1;
                direccion = 1;
            }
        }
        public void MoveDown()
        {
            if (pY != 29)
            {
                pY += 1;
                direccion = 2;
            }
        }
        public void MoveLeft()
        {
            if (pX != 0)
            {
                pX -= 1;
                direccion = 3;
            }
        }
        public void MoveRight()
        {
            if (pX != 119)
            {
                pX += 1;
                direccion = 4;
            }
        }
        public void DibujarVidas()
        {
            Console.SetCursorPosition(0, 0);
            switch(vidas)
            {
                case 1:
                    Console.Write("♥");
                    break;
                case 2:
                    Console.Write("♥♥");
                    break;
                case 3:
                    Console.Write("♥♥♥");
                    break;
            }
        }

    }
}
