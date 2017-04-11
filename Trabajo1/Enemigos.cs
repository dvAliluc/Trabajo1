using System;

namespace Game
{
    class Enemigos
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
        public void Show()
        {
            Console.SetCursorPosition(pX, pY);
            Console.WriteLine(Char);


        }
        public void setChar(char ch)
        {
            Char = ch;

        }
        public void setPosX(int X)
        {
            pX = X;
        }
        public void setPosY( int Y)
        {
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
        public void MoveLeft()
        {
            if (pX== 0)
            {
                pX=118;
            }
            else
            {
                pX -= 1;
            }
        }
        public void MoveRight()
        {
            if (pX == 118)
            {
                pX = 1;
            }
            else
            {
                pX += 1;
            }
        }
        public void MoveUp()
        {
            if (pY == 0)
            {
                pY = 29;
            }
            pY -= 1;
        }
        public void MoveDown()
        {
            if (pY == 30)
            {
                pY = 0;
            }
            pY += 1;
        }
        
        



    }
}

