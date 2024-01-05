﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLua;

namespace Lynox.SEF.Additional_Compilers.LUA
{
    public class LUA : Compiler
    {

        public LUA()
        {

            this.COMPILER_EXTENSION = ".lua";
            this.COMPILER_NAME = "LUA";

        }

        public override void Execute(string code)
        {
            try
            {

                // Create a new Lua state
                ILuaState lua = LuaAPI.NewState();
                lua.L_OpenLibs(); // Open the Lua libraries
                                  // Define a CSharpFunctionDelegate

                // Define a Lua script that returns a value
                string script = code;

                // Load and run the Lua script
                var status = lua.L_LoadString(script);
                if (status != 0)
                {
                    Console.WriteLine("Error loading script: " + lua.ToString(-1));
                    return;
                }

                status = lua.PCall(0, 1, 0);
                if (status != 0)
                {
                    Console.WriteLine("Error running script: " + lua.ToString(-1));
                    return;
                }

                // Get the output from the Lua script
                string output = lua.ToString(-1);
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.WriteLine("ex:" + e.Message + "\n");
            }
        }

    }
}
