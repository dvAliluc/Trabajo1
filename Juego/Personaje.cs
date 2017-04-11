using System;

namespace Game
{
    class Personaje
    {
        private int pX;
        private int pY;
        private char Char;

        
        public void Start(int _x , int _y , char pj)
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
                pY -= 1;
        }
        public void MoveDown()
        {
            if (pY != 30)
                pY += 1;
        }
        public void MoveLeft()
        {
            if (pX != 0)
                pX -= 1;
        }
        public void MoveRight()
        {
            if (pX != 119)
                pX += 1;
        }

    }
}
