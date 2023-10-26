using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using Lynox.ConsoleMode;
using Lynox.SystemUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lynox.GraphicMode
{
    internal class graphics
    {

        public static Canvas canvas;

        public static void entry(uint collumns = 1280,uint rows = 720)
        {

            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(collumns,rows,ColorDepth.ColorDepth32));
            MouseManager.ScreenWidth = collumns;
            MouseManager.ScreenHeight = rows;

            ProcessUpdates();

        }

        static void ProcessUpdates()
        {

            while (true)
            {
                canvas.Clear(Color.DodgerBlue);
                canvas.DrawFilledRectangle(Color.DarkGray, 0, (int)canvas.Mode.Height - 30, (int)canvas.Mode.Width, 30);
                UpdateMouse();
                canvas.Display();
                Heap.Collect();
            }

        }

        static void UpdateMouse()
        {

            canvas.DrawFilledRectangle(Color.White,(int)MouseManager.X,(int)MouseManager.Y,10,10);

        }

    }
}
