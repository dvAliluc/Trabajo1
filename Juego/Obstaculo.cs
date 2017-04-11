using System;

namespace Game
{
    class Obstaculo
    {
        private int pX;
        private int pY;
        private char Char;


        public void Start(int _x, int _y, char pj)
        {
            pX = _x;
            pY = _y;
            Char = pj;

        }
        public void setChar(char ch)
        {
            Char = ch;

        }
        public void setPos(int X , int Y)
        {
            pX = X;
            pY = Y;


        }
        public int getPosX()
        {
            return pX;
        }
        public int getPosY()
        {

            return pY;
        }
        public void Show()
        {
            Console.SetCursorPosition(pX, pY);
            Console.WriteLine(Char);


        }
    }
}
