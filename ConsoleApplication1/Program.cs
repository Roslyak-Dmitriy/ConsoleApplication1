using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    struct Square
    {
        int hight;
        int width;

        int LeftPos;
        int TopPos;
        
        public Square(int size,int x,int y)
        {
            hight = size;
            width = hight;
            TopPos = y;
            LeftPos = x;
        }
        public void show()
        {
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(LeftPos + i, TopPos + j);
                    Console.Write("*");
                }
            }
        }
        public void show(int left,int top)
        {
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(LeftPos + i+left, TopPos + j+top);
                    Console.Write("X");
                }
            }
        }
        public void PhysX(Square b,int curleftpos, int curtoppos)
        {
            int temp = 0;
            for (int ac = 0; ac < hight; ac++)
            {
                for (int ja = 0; ja < width; ja++)
                {
                    for (int i = 0; i < b.hight; i++)
                    {
                        for (int j = 0; j < b.width; j++)
                        {
                            if (ac + curleftpos == b.LeftPos + i && ja + curtoppos == b.TopPos + j)
                            {
                                temp = 1;
                            }
                        }
                    }
                }
            }
            if (temp == 1)
            {
                //Console.Write("It works!");
                Console.Beep(); 
            }
        }
        public void _PhysX(int a,int b)
        { 
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (a == LeftPos + i && b == TopPos + j)
                    {
                        //Console.Write("^G");
                        Console.Beep();
                    }
                }
            }
        }
    }
    class Coordinate
    {
        int top;
        int left;
        public Coordinate()
        {
            top = 0;
            left = 0;
        }
        public Coordinate(int top,int left)
        {
            this.top = top;
            this.left = left;
        }
        public void Left()
        {
            left--;
            if (left < 0) { left = 0; }
        }
        public void Right()
        {
            left++;
            if (left > 60) { left = 0; }
        }
        public void Up()
        {
            top--;
            if (top < 0) { top = 0; }
        }
        public void Down()
        {
            top++;
            if (top > 60) { top = 0; }
        }
        public int GetTop()
        {
            return top;
        }
        public int GetLeft()
        {
            return left;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            Square sq1 = new Square(5,10,2);
            Square sq2 = new Square(6,20,10);
            Square sq3 = new Square(2, 0, 0);

            Coordinate cursor = new Coordinate();

            do
            {
                key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    cursor.Left();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    cursor.Right();
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    cursor.Up();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    cursor.Down();
                }
                sq1.show();
                sq2.show();

                sq3.show(cursor.GetLeft(), cursor.GetTop());

                sq3.PhysX(sq1, cursor.GetLeft(), cursor.GetTop());
                sq3.PhysX(sq2, cursor.GetLeft(), cursor.GetTop());
            }
            while (key.Key != ConsoleKey.Escape);
        } 
    }
}
