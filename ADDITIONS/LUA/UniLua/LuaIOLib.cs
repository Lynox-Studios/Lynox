
// TODO

using System;
using System.IO;

namespace UniLua
{

	internal class  LuaIOLib
	{
		public const string LIB_NAME = "io";

		public static int OpenLib( ILuaState lua )
		{
			NameFuncPair[] define = new NameFuncPair[]
			{
				new NameFuncPair( "close", 		IO_Close ),
				new NameFuncPair( "flush", 		IO_Flush ),
				new NameFuncPair( "input", 		IO_Input ),
				new NameFuncPair( "lines", 		IO_Lines ),
				new NameFuncPair( "open", 		IO_Open ),
				new NameFuncPair( "output", 	IO_Output ),
				new NameFuncPair( "popen", 		IO_Popen ),
				new NameFuncPair( "read", 		IO_Read ),
				new NameFuncPair( "tmpfile", 	IO_Tmpfile ),
				new NameFuncPair( "type", 		IO_Type ),
				new NameFuncPair( "write", 		IO_Write ),
			};

			lua.L_NewLib( define );
			return 1;
		}

		private static int IO_Close( ILuaState lua )
		{
			
			return 0;
		}

		private static int IO_Flush( ILuaState lua )
		{
			// TODO
			return 0;
		}

		private static int IO_Input( ILuaState lua )
		{
			// TODO
			return 0;
		}

		private static int IO_Lines( ILuaState lua )
		{
			// TODO
			return 0;
		}

		private static int IO_Open( ILuaState lua )
		{

			switch (lua.ToString(2))
			{

				case "r":
					File.OpenRead(lua.ToString(1));
					break;
				case "w":
					File.OpenWrite(lua.ToString(1));
					break;
                case "a":
                    File.Open(lua.ToString(1),FileMode.Append);
                    break;
                case "a+":
                    File.Open(lua.ToString(1), FileMode.Append);
                    break;
                case "r+":
                    File.OpenText(lua.ToString(1));
                    break;
                case "w+":
                    File.OpenWrite(lua.ToString(1));
                    break;
                default:
					break;
			}
			return 0;
		}

		private static int IO_Output( ILuaState lua )
		{
			// TODO
			return 0;
		}

		private static int IO_Popen( ILuaState lua )
		{
			// TODO
			return 0;
		}

		private static int IO_Read( ILuaState lua )
		{
			lua.PushString("unreadable");

            if (string.IsNullOrEmpty(lua.ToString(1)))
			{
                lua.PushString(Console.ReadLine());
            }
			else
			{
                lua.PushString(File.ReadAllText(lua.ToString(1)));
            }
			return 0;
		}

		private static int IO_Tmpfile( ILuaState lua )
		{
			// TODO
			return 0;
		}

		private static int IO_Type( ILuaState lua )
		{
			// TODO
			return 0;
		}

		private static int IO_Write( ILuaState lua )
		{

			return 0;
		}
	}

}

