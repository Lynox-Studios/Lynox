using Cosmos.System;
using Cosmos.System.Graphics;
using TestDistro.ConsoleMode;
using Lynox.SEF.CLI;
using Lynox.SEF.CPU;
using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDistro.GraphicMode
{
    internal class graphics
    {

        public static bool isgui = false;
        public static Canvas canvas;

        public static void entry(uint collumns = 1280,uint rows = 720)
        {

            isgui = true;
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(collumns,rows,ColorDepth.ColorDepth32));
            MouseManager.ScreenWidth = collumns;
            MouseManager.ScreenHeight = rows;
            canvas.Clear(Color.DodgerBlue);
            ProcessUpdates();
            canvas.Display();
        }

        static void ProcessUpdates()
        {

            SEF_CPU.Execute("0:\\bin\\GUITB.lex");

            while (true)
            {
                //canvas.Clear(Color.DodgerBlue);
                //canvas.DrawFilledRectangle(Color.DarkGray, 0, (int)canvas.Mode.Height - 30, (int)canvas.Mode.Width, 30);
                //UpdateMouse();
                canvas.Display();

            }

        }

        static void UpdateMouse()
        {

            canvas.DrawFilledRectangle(Color.White,(int)MouseManager.X,(int)MouseManager.Y,10,10);

        }

    }
}
