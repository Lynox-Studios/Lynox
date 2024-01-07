using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLua;

namespace Lynox.ADDITIONS.LUA.APIs
{
    public static class LUA_LYNOXGRAPHICS
    {
        public const string LIB_NAME = "lynoxAPI.graphics";

        static Canvas LUA_CANVAS;

        public static int OpenLib(ILuaState lua)
        {
            var define = new NameFuncPair[]
            {
            new NameFuncPair("createcanvas", LUA_CREATECANVAS),
            new NameFuncPair("clearcanvas", LUA_CLEARCANVAS),
            new NameFuncPair("drawfilledrect", LUA_DRAWFILLEDRECT),
            new NameFuncPair("drawrect", LUA_DRAWRECT),
            new NameFuncPair("displaycanvas", LUA_DISPLAYCANVAS),
            };
            lua.L_NewLib(define);
            return 1;
        }
        //FILES
        public static int LUA_CREATECANVAS(ILuaState lua)
        {

            LUA_CANVAS = FullScreenCanvas.GetFullScreenCanvas(new Mode((uint)lua.ToInteger(1), (uint)lua.ToInteger(2),ColorDepth.ColorDepth32));
            return 1;
        }
        public static int LUA_CLEARCANVAS(ILuaState lua)
        {

            LUA_CANVAS.Clear(Color.FromArgb(lua.ToInteger(1), lua.ToInteger(2), lua.ToInteger(3)));
            return 1;
        }
        public static int LUA_DISPLAYCANVAS(ILuaState lua)
        {

            LUA_CANVAS.Display();
            return 1;
        }
        public static int LUA_DRAWFILLEDRECT(ILuaState lua)
        {

            LUA_CANVAS.DrawFilledRectangle(Color.FromArgb(lua.ToInteger(5), lua.ToInteger(6), lua.ToInteger(7)), lua.ToInteger(1), lua.ToInteger(2), lua.ToInteger(3), lua.ToInteger(4));
            return 1;
        }
        public static int LUA_DRAWRECT(ILuaState lua)
        {

            LUA_CANVAS.DrawRectangle(Color.FromArgb(lua.ToInteger(5), lua.ToInteger(6), lua.ToInteger(7)), lua.ToInteger(1), lua.ToInteger(2), lua.ToInteger(3), lua.ToInteger(4));
            return 1;
        }
    }
}
