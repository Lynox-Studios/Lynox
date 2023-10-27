using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDistro.ConsoleMode;

namespace Lynox.SystemUtils
{
    public class ProgressBar
    {

        public int max;
        public (int left,int top) cursorpos;
        public int percentage;

        public void Init(int left,int top) { cursorpos.left = left;cursorpos.top = top; Draw(); }

        public void Increment(int value = 1)
        {

            percentage += value;
            Draw();

        }
        public void Decrement(int value = 1)
        {

            percentage -= value;
            Draw();

        }
        public void Set(int value = 1)
        {

            percentage = value;
            Draw();

        }

        public void Draw()
        {

            var pcpos = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorpos.left, cursorpos.top);
            Console.Write('[');
            for (int i = 0; i < max; i++)
            {

                if ((i + 1) <= percentage)
                {

                    Console.Write('|');

                }
                else
                {
                    Console.Write('-');
                }

            }
            Console.Write(']');
            Console.SetCursorPosition(pcpos.Left,pcpos.Top);
        }

    }
}
